using Domain.Entities;
using Application.Dto.Lead;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Patient;
using Application.General.Dto;
using Application.Dto.Appointment;

namespace Application.ServiceInterfaces.IProviderServices
{
    public interface IAppointmentService
    {
        Appointment UpsertAppointment(UpsertAppointmentDto upsertAppointmentDto);
        List<AppointmentDto> GetAppointmentsByProviderID(int providerID);
        List<AppointmentDto> GetAppointmentsByPatientID(int patientID);
        AppointmentDto GetAppointmentByID(int id);
        Appointment ConfirmAppointmentByID(int id);
        Appointment CancelAppointmentByID(int id);
    }

}
