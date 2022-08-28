using Domain;
using Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using Application.Dto.Appointment;
using Domain.Exceptions;
using Application.ServiceInterfaces.IProviderServices;
using Application.RepositoryInterfaces.IProviderRepositories;
using Application.RepositoryInterfaces.IPatientRepositories;
using System.Linq;
using Application.Dto.Provider;
using Application.Helper;
using Newtonsoft.Json;

namespace Application.Services.ProviderServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IProviderAvailabilityRepository _providerAvailabilityRepository;
        private readonly IProviderUnavailabilityRepository _providerUnavailabilityRepository;

        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            IProviderRepository providerRepository,
            IPatientRepository patientRepository,
            IProviderAvailabilityRepository providerAvailabilityRepository,
            IProviderUnavailabilityRepository providerUnavailabilityRepository,
            IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _providerRepository = providerRepository;
            _patientRepository = patientRepository;
            _providerAvailabilityRepository = providerAvailabilityRepository;
            _providerUnavailabilityRepository = providerUnavailabilityRepository;
            _mapper = mapper;
        }

        public Appointment UpsertAppointment(UpsertAppointmentDto upsertAppointmentDto)
        {
            try
            {
                upsertAppointmentDto.BookingStartDateTime = upsertAppointmentDto.BookingStartDateTime.AddSeconds(-upsertAppointmentDto.BookingStartDateTime.Second);
                upsertAppointmentDto.BookingEndDateTime = upsertAppointmentDto.BookingEndDateTime.AddSeconds(-upsertAppointmentDto.BookingEndDateTime.Second);
                Appointment appointment = null;
                var patient = _patientRepository.GetPatientWithDetails(upsertAppointmentDto.PatientID);
                var provider = _providerRepository.GetActiveProvider(upsertAppointmentDto.ProviderID);
                if (patient == null)
                {
                    throw new BadRequestException($"Patient with ID '{upsertAppointmentDto.PatientID}' not found");
                }
                else if (provider == null)
                {
                    throw new BadRequestException($"Provider with ID '{upsertAppointmentDto.ProviderID}' not found");
                }
                else
                {
                    if (upsertAppointmentDto.ID == 0)
                    {
                        if (ValidateAppointmentTime(upsertAppointmentDto.BookingStartDateTime, upsertAppointmentDto.BookingEndDateTime, provider.ID, patient.ID))
                        {
                            appointment = new Appointment
                            {
                                BookingStartDateTime = upsertAppointmentDto.BookingStartDateTime,
                                BookingEndDateTime = upsertAppointmentDto.BookingEndDateTime,
                                Active = true,
                                Approved = false,
                                Cancelled = false,
                                fk_PatientID = patient.ID,
                                fk_ProviderID = provider.ID,
                                Notes = upsertAppointmentDto.Notes,
                                Total = 0,
                                RawData = JsonConvert.SerializeObject(upsertAppointmentDto)
                            };
                            _appointmentRepository.Add(appointment);
                        }
                    }
                    else
                    {
                        appointment = _appointmentRepository.GetFirst(c => c.ID == upsertAppointmentDto.ID && c.Active);
                        if (appointment == null)
                        {
                            throw new BadRequestException($"Appointment with ID '{upsertAppointmentDto.ID}' not found");
                        }
                        else
                        {
                            bool IsReschedule = false;
                            if (appointment.BookingStartDateTime != upsertAppointmentDto.BookingStartDateTime || appointment.BookingEndDateTime != upsertAppointmentDto.BookingEndDateTime)
                            {
                                ValidateAppointmentTime(upsertAppointmentDto.BookingStartDateTime, upsertAppointmentDto.BookingEndDateTime, provider.ID, patient.ID, appointment.ID);
                                IsReschedule = true;
                            }
                            appointment.BookingStartDateTime = upsertAppointmentDto.BookingStartDateTime;
                            appointment.BookingEndDateTime = upsertAppointmentDto.BookingEndDateTime;
                            appointment.fk_PatientID = patient.ID;
                            appointment.fk_ProviderID = provider.ID;
                            appointment.Notes = upsertAppointmentDto.Notes;
                            appointment.RawData = JsonConvert.SerializeObject(upsertAppointmentDto);
                            appointment.Rescheduled = IsReschedule;
                            appointment.Total = 0;
                        }

                    }
                    _appointmentRepository.Complete();

                }
                return appointment;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<AppointmentDto> GetAppointmentsByProviderID(int providerID)
        {
            var appointments = _appointmentRepository.GetAppointmentsByProviderID(providerID);
            return _mapper.Map<List<Appointment>, List<AppointmentDto>>(appointments);
        }
        public List<AppointmentDto> GetAppointmentsByPatientID(int patientID)
        {
            var appointments = _appointmentRepository.GetAppointmentsByPatientID(patientID);
            return _mapper.Map<List<Appointment>, List<AppointmentDto>>(appointments);
        }
        private bool ValidateAppointmentTime(DateTime appointmentStartTime, DateTime appointmentEndTime, int providerID, int patientID, int appointmentID = 0)
        {
            IList<ProviderAvailability> providerAvailabilities = null;
            List<ProviderAvailabilityByDateTime> providerAvailabilityByDateTimes = new List<ProviderAvailabilityByDateTime>();
            var providerAppointments = _appointmentRepository.GetMany(c => c.fk_ProviderID == providerID && c.Active && !c.Cancelled && c.ID != appointmentID);
            var patientAppointments = _appointmentRepository.GetMany(c => c.fk_PatientID == patientID && c.Active && !c.Cancelled && c.ID != appointmentID);
            var providerUnavailabilities = _providerUnavailabilityRepository.GetMany(c => c.fk_ProviderID == providerID && !c.Deleted);
            if (appointmentStartTime.Date == appointmentEndTime.Date)
            {
                providerAvailabilities = _providerAvailabilityRepository.GetMany(c => c.fk_ProviderID == providerID && !c.Deleted && c.DayOfWeek == appointmentStartTime.DayOfWeek.GetHashCode());
            }
            else
            {
                providerAvailabilities = _providerAvailabilityRepository.GetMany(c => c.fk_ProviderID == providerID && !c.Deleted && (c.DayOfWeek == appointmentStartTime.DayOfWeek.GetHashCode() || c.DayOfWeek == appointmentStartTime.AddDays(1).DayOfWeek.GetHashCode()));
            }
            foreach (var item in providerAvailabilities)
            {
                providerAvailabilityByDateTimes.Add(new()
                {
                    ID = item.ID,
                    DayOfWeek = item.DayOfWeek,
                    StartTime = item.FromTime.ToDateTime(item.DayOfWeek, appointmentStartTime),
                    EndTime = item.ToTime.ToDateTime(item.DayOfWeek, appointmentEndTime),
                    Deleted = false
                });
            }
            providerAvailabilityByDateTimes = providerAvailabilityByDateTimes.OrderBy(x => x.StartTime).ToList();
            // merge midnight slots
            for (int i = 0; i < providerAvailabilityByDateTimes.Count; i++)
            {
                if ((i + 1) < providerAvailabilities.Count)
                {
                    var totalMinutes = providerAvailabilityByDateTimes[i + 1].StartTime.Subtract(providerAvailabilityByDateTimes[i].EndTime).TotalMinutes;
                    if (totalMinutes == 0 || totalMinutes == 1)
                    {
                        // if the current availabaility is deleted by previous availability then merge it to previous availability
                        if (providerAvailabilityByDateTimes[i].Deleted)
                        {
                            var currentIndex = i - 1;
                            while (currentIndex >= 0)
                            {
                                if (providerAvailabilityByDateTimes[currentIndex].Deleted)
                                {
                                    currentIndex--;
                                }
                                else
                                {
                                    providerAvailabilityByDateTimes[currentIndex].EndTime = providerAvailabilityByDateTimes[i + 1].EndTime;
                                    currentIndex = -1;
                                }
                            }
                        }
                        else
                        {
                            providerAvailabilityByDateTimes[i].EndTime = providerAvailabilityByDateTimes[i + 1].EndTime;
                        }
                        providerAvailabilityByDateTimes[i + 1].Deleted = true;
                    }

                }
            }
            providerAvailabilityByDateTimes = providerAvailabilityByDateTimes.Where(c => !c.Deleted).OrderBy(x => x.StartTime).ToList();

            if (providerAppointments.Any(c => c.BookingStartDateTime < appointmentEndTime && appointmentStartTime < c.BookingEndDateTime))
            {
                throw new BadRequestException($"Appointment time has a conflict with existing provider appointments");
            }
            else if (patientAppointments.Any(c => c.BookingStartDateTime < appointmentEndTime && appointmentStartTime < c.BookingEndDateTime))
            {
                throw new BadRequestException($"Appointment time has a conflict with existing patient appointments");
            }
            else if (providerUnavailabilities.Any(c => c.FromDateTime < appointmentEndTime && appointmentStartTime < c.ToDateTime))
            {
                throw new BadRequestException($"Provider is unavailable at this appointment time");
            }
            else if (!providerAvailabilityByDateTimes.Any(c => appointmentStartTime >= c.StartTime && appointmentEndTime <= c.EndTime))
            {
                throw new BadRequestException($"Provider is unavailable at this appointment time");
            }
            return true;
        }

        public Appointment ConfirmAppointmentByID(int id)
        {
            Appointment appointment = _appointmentRepository.GetFirst(x => x.ID == id && x.Active && !x.Cancelled);
            try
            {
                if (appointment == null)
                {
                    throw new BadRequestException($"Appointment '{id}' not found");
                }
                else if (appointment != null && appointment.Approved)
                {
                    throw new BadRequestException($"Appointment '{id}' Already Confirmed");
                }
                else
                {
                    appointment.Approved = true;
                    _appointmentRepository.Update(appointment);
                    _appointmentRepository.Complete();
                }
                return appointment;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Appointment CancelAppointmentByID(int id)
        {
            Appointment appointment = _appointmentRepository.GetFirst(x => x.ID == id && x.Active);
            try
            {
                if (appointment == null)
                {
                    throw new BadRequestException($"Appointment '{id}' not found");
                }
                else if (appointment != null && appointment.Cancelled)
                {
                    throw new BadRequestException($"Appointment '{id}' already Cancelled");
                }
                else
                {
                    appointment.Cancelled = true;
                    appointment.Active = false;
                    _appointmentRepository.Update(appointment);
                    _appointmentRepository.Complete();
                }
                return appointment;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public AppointmentDto GetAppointmentByID(int id)
        {
            var appointments = _appointmentRepository.GetAppointmentByID(id);
            return _mapper.Map<Appointment, AppointmentDto>(appointments);
        }
    }
}
