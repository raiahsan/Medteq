using Domain;
using Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Enums = Domain.Enums;
using Newtonsoft.Json;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using Application.Dto.Lead;
using Application.Dto.Patient;
using Application.Helper;
using Application.General.Dto;
using Application.Dto.PatientProvider;
using System.Linq;
using Domain.Exceptions;
using Application.ServiceInterfaces.IPatientServices;
using Application.RepositoryInterfaces.IPatientRepositories;
using Application.RepositoryInterfaces.IGeneralRepositories;
using Application.RepositoryInterfaces.IProviderRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;

namespace Application.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IAddressTypeRepository _addressTypeRepository;
        private readonly IContactTypeRepository _contactTypeRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IMaritalStatusRepository _maritalStatusRepository;
        private readonly IRelationshipTypeRepository _relationshipTypeRepository;
        private readonly IStateRepository _stateRepository;
        private readonly IPatientAddressRepository _patientAddressRepository;
        private readonly IPatientContactRepository _patientContactRepository;
        private readonly IProviderTypeRepository _providerTypeRepository;
        private readonly IPatientProviderRepository _patientProviderRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IPatientDiagnosisRepository _patientDiagnosisRepository;
        private readonly IDiagnosisRepository _diagnosisRepository;


        public PatientService(
            IPatientRepository patientRepository,
            IMapper mapper,
            IBranchRepository branchRepository,
            IAddressTypeRepository addressTypeRepository,
            IContactTypeRepository contactTypeRepository,
            IGenderRepository genderRepository,
            IMaritalStatusRepository maritalStatusRepository,
            IRelationshipTypeRepository relationshipTypeRepository,
            IStateRepository stateRepository,
            IPatientAddressRepository patientAddressRepository,
            IPatientContactRepository patientContactRepository,
            IProviderTypeRepository providerTypeRepository,
            IPatientProviderRepository patientProviderRepository,
            IProviderRepository providerRepository,
            IPatientDiagnosisRepository patientDiagnosisRepository,
            IDiagnosisRepository diagnosisRepository)
        {
            _patientRepository = patientRepository;
            _branchRepository = branchRepository;
            _addressTypeRepository = addressTypeRepository;
            _contactTypeRepository = contactTypeRepository;
            _genderRepository = genderRepository;
            _maritalStatusRepository = maritalStatusRepository;
            _relationshipTypeRepository = relationshipTypeRepository;
            _stateRepository = stateRepository;
            _patientAddressRepository = patientAddressRepository;
            _patientContactRepository = patientContactRepository;
            _providerTypeRepository = providerTypeRepository;
            _patientProviderRepository = patientProviderRepository;
            _providerRepository = providerRepository;
            _patientDiagnosisRepository = patientDiagnosisRepository;
            _diagnosisRepository = diagnosisRepository;
            _mapper = mapper;
        }
        public async Task<Patient> UpsertPatient(CreatePatientDto patientDto)
        {
            try
            {
                Branch branch = _branchRepository.GetFirst(c => c.Active && String.Compare(c.BranchName, patientDto.Branch, StringComparison.OrdinalIgnoreCase) == 0);
                if (!String.IsNullOrWhiteSpace(patientDto.Branch) && branch == null)
                {
                    throw new BadRequestException($"Branch '{patientDto.Branch}' not found");
                }
                else
                {
                    Patient patient = null;
                    if (patientDto.ID == 0)
                    {
                        patient = new Patient();
                        patient.PatientGUID = Guid.NewGuid();
                        await _patientRepository.Add(patient);
                    }
                    else
                    {
                        patient = _patientRepository.GetPatientWithDetails(patientDto.ID);
                        if (patient == null)
                        {
                            throw new BadRequestException($"Patient '{patientDto.ID}' not found");
                        }
                    }
                    patient.PatientGUID = Guid.NewGuid();
                    patient.fk_GenderID = _genderRepository.GetGender(patientDto.Gender)?.ID;
                    patient.fk_MaritalStatusID = _maritalStatusRepository.GetMaritalStatus(patientDto.MaritalStatus)?.ID;
                    patient.fk_BranchID = branch?.ID;
                    patient.AccountNumber = patientDto.AccountNumber;
                    patient.DateOfAdmission = patientDto.DateOfAdmission?.Date;
                    patient.DateOfDischarge = patientDto.DateOfDischarge?.Date;
                    patient.DateOfOnset = patientDto.DateOfOnset?.Date;
                    patient.DiscountPct = patientDto.DiscountPct;
                    patient.DOB = patientDto.DOB?.Date;
                    patient.DOD = patientDto.DOD?.Date;
                    patient.MobileVerifiedDate = patientDto.MobileVerifiedDate;
                    patient.EmailAddress = patientDto.EmailAddress;
                    patient.EmailVerifiedDate = patientDto.EmailVerifiedDate;
                    patient.FaxNumber = patientDto.FaxNumber;
                    patient.Height = patientDto.Height;
                    patient.Weight = patientDto.Weight;
                    patient.HippasignatureOnFile = patientDto.HippasignatureOnFile;
                    patient.HoldAcct = patientDto.HoldAcct;
                    patient.Suffix = patientDto.Suffix;
                    patient.SSN = patientDto.SSN.RemoveSpecialCharacters();
                    patient.StateOfAutoAccident = patientDto.StateOfAutoAccident;
                    patient.MiddleName = patientDto.MiddleName;
                    patient.FirstName = patientDto.FirstName;
                    patient.LastName = patientDto.LastName;
                    patient.MobilePhone = patientDto.MobilePhone.RemoveSpecialCharacters();

                    _patientContactRepository.Delete(c => c.fk_PatientID == patient.ID);
                    patient.PatientContacts.Clear();

                    if (patientDto.Contacts?.Count > 0)
                    {
                        foreach (var item in patientDto.Contacts)
                        {
                            patient.PatientContacts.Add(new PatientContact
                            {
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                Email = item.Email,
                                FaxNumber = item.FaxNumber,
                                MobileNumber = item.MobileNumber.RemoveSpecialCharacters(),
                                PhoneNumber = item.PhoneNumber.RemoveSpecialCharacters(),
                                AddressLine1 = item.AddressLine1,
                                AddressLine2 = item.AddressLine2,
                                City = item.City,
                                fk_StateID = _stateRepository.GetState(item.State)?.ID,
                                PostalCode = item.PostalCode,
                                Active = true,
                                fk_ContactTypeID = _contactTypeRepository.GetContactType(item.ContactType)?.ID ?? 0,
                                fk_RelationshipTypeID = _relationshipTypeRepository.GetRelationshipType(item.RelationshipType)?.ID ?? 0,
                            });
                        }
                    }
                    _patientAddressRepository.Delete(c => c.fk_PatientID == patient.ID);
                    patient.PatientAddresses.Clear();

                    if (patientDto.Addresses?.Count > 0)
                    {
                        foreach (var item in patientDto.Addresses)
                        {
                            patient.PatientAddresses.Add(new PatientAddress
                            {
                                MobileNumber = item.MobileNumber.RemoveSpecialCharacters(),
                                PhoneNumber = item.PhoneNumber.RemoveSpecialCharacters(),
                                AddressLine1 = item.AddressLine1,
                                AddressLine2 = item.AddressLine2,
                                PostalCode = item.PostalCode,
                                City = item.City,
                                ContactPersonName = item.ContactPersonName,
                                fk_StateID = _stateRepository.GetState(item.State)?.ID ?? 0,
                                fk_AddressTypeID = _addressTypeRepository.GetAddressType(item.AddressType)?.ID ?? 0,
                            });
                        }
                    }
                    await _patientRepository.Add(patient);
                    _patientRepository.Complete();
                    return patient;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public GetPatientDto GetPatientByID(int id)
        {
            var patient = _patientRepository.GetPatientWithDetails(id);
            return _mapper.Map<Patient, GetPatientDto>(patient);
        }

        public RecordSet<Patient> GetPatients(PatientSearchDto patientSearch)
        {
            try
            {
                return _patientRepository.GetPatients(patientSearch);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PatientAddressDto> GetPatientAddressesByPatientID(int patientID)
        {
            var patient = _patientAddressRepository.GetAddressesByPatientID(patientID);
            return _mapper.Map<List<PatientAddress>, List<PatientAddressDto>>(patient);

        }

        public List<PatientContactDto> GetPatientContactByPatientID(int patientID)
        {
            var patient = _patientContactRepository.GetContactsByPatientID(patientID);
            return _mapper.Map<List<PatientContact>, List<PatientContactDto>>(patient);

        }

        public List<PatientProvider> UpsertPatientProviders(UpsertPatientProviderDto upsertProviderDto)
        {
            try
            {
                List<PatientProvider> patientProviders = new List<PatientProvider>();
                Patient patient = _patientRepository.GetPatientWithDetails(upsertProviderDto.PatientID);
                var providersIdsInRequest = upsertProviderDto.PatientProviders.Select(x => x.ProviderID).Distinct().ToList();
                var providersInDb = _providerRepository.GetMany(x => providersIdsInRequest.Any(c => x.ID == c));
                var providersNotInDb = providersIdsInRequest.Where(x => !providersInDb.Any(c => c.ID == x)).ToList();


                var providerToDeleted = providersInDb.Where(x => !providersIdsInRequest.Any(c => x.ID == c)).ToList();

                if (providersNotInDb?.Count > 0)
                {
                    throw new BadRequestException($"Providers '{string.Join(',', providersNotInDb)}' not Exist");
                }
                else if (patient == null)
                {
                    throw new BadRequestException($"Patient '{upsertProviderDto.PatientID}' not found");
                }
                else
                {
                    var patientProvidersInDB = _patientProviderRepository.GetMany(x => x.fk_PatientID == patient.ID && !x.Deleted);
                    var patientProvidersToAdd = upsertProviderDto.PatientProviders.Where(x => !patientProvidersInDB.Any(c => x.ProviderID == c.fk_ProviderID && x.ProviderTypeID == c.fk_ProviderTypeID));

                    var patientProvidersToDelete = patientProvidersInDB.Where(x => !providersIdsInRequest.Any(c => x.fk_ProviderID == c && x.fk_ProviderTypeID == c));

                    foreach (var item in patientProvidersToDelete)
                    {
                        item.Deleted = true;
                    }
                    foreach (var item in patientProvidersToAdd)
                    {
                        patientProviders.Add(new PatientProvider
                        {
                            fk_PatientID = upsertProviderDto.PatientID,
                            fk_ProviderID = item.ProviderID,
                            fk_ProviderTypeID = item.ProviderTypeID,
                            Deleted = false
                        });
                    }
                }
                _patientProviderRepository.AddRange(patientProviders);
                _patientProviderRepository.Complete();
                return patientProviders;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GetPatientProviderDto> GetPatientProvidersByPatientID(int patientID)
        {
            var patientProvider = _patientProviderRepository.GetPatientProvidersByPatientID(patientID);
            return _mapper.Map<List<PatientProvider>, List<GetPatientProviderDto>>(patientProvider);
        }

        public PatientProviderDto DeletePatientProvider(int id)
        {
            try
            {
                PatientProvider patientProvider = _patientProviderRepository.GetFirst(c => c.ID == id && !c.Deleted);
                if (patientProvider != null)
                {
                    patientProvider.Deleted = true;
                    _patientProviderRepository.Complete();
                }
                else
                {
                    throw new BadRequestException($"PatientProvider '{id}' not found");
                }
                return _mapper.Map<PatientProviderDto>(patientProvider);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public PatientDiagnosis UpsertPatientDiagnosis(UpsertPatientDiagnosisDto patientDiagnosisDto)
        {
            try
            {
                PatientDiagnosis patientDiagnosis = null;
                Patient patient = _patientRepository.GetPatientWithDetails(patientDiagnosisDto.PatientID);
                Diagnosis diagnosis = _diagnosisRepository.GetFirst(c => c.ID == patientDiagnosisDto.DiagnosisID && c.Active);

                if (patient == null)
                {
                    throw new BadRequestException($"Patient with ID '{patientDiagnosisDto.PatientID}' not found");
                }
                else if (diagnosis == null)
                {
                    throw new BadRequestException($"Diagnosis with ID '{patientDiagnosisDto.DiagnosisID}' not found");
                }
                else
                {
                    if (patientDiagnosisDto.ID == 0)
                    {
                        patientDiagnosis = new PatientDiagnosis
                        {
                            fk_DiagnosisID = patientDiagnosisDto.DiagnosisID,
                            fk_PatientID = patientDiagnosisDto.PatientID,
                            Sequence = patientDiagnosisDto.Sequence,
                            ShortDescription = patientDiagnosisDto.ShortDescription,
                            IsDeleted = false,
                        };
                        _patientDiagnosisRepository.Add(patientDiagnosis);
                    }
                    else
                    {
                        patientDiagnosis = _patientDiagnosisRepository.GetFirst(c => c.ID == patientDiagnosisDto.ID && !c.IsDeleted);
                        if (patientDiagnosis != null)
                        {
                            patientDiagnosis.fk_DiagnosisID = patientDiagnosisDto.DiagnosisID;
                            patientDiagnosis.fk_PatientID = patientDiagnosisDto.PatientID;
                            patientDiagnosis.Sequence = patientDiagnosisDto.Sequence;
                            patientDiagnosis.ShortDescription = patientDiagnosisDto.ShortDescription;
                            patientDiagnosis.IsDeleted = false;
                            _patientDiagnosisRepository.Update(patientDiagnosis);
                        }
                        else
                        {
                            throw new BadRequestException($"PatientDiagnosis with ID '{patientDiagnosisDto.ID}' not found");
                        }
                    }
                    _patientDiagnosisRepository.Complete();
                    return patientDiagnosis;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public PatientDiagnosisDto DeletePatientDiagnosis(int id)
        {
            try
            {
                PatientDiagnosis patientDiagnosis = _patientDiagnosisRepository.GetFirst(c => c.ID == id && !c.IsDeleted);
                if (patientDiagnosis != null)
                {
                    patientDiagnosis.IsDeleted = true;
                    _patientProviderRepository.Complete();
                }
                else
                {
                    throw new BadRequestException($"PatientDiagnosis '{id}' not found");
                }
                return _mapper.Map<PatientDiagnosisDto>(patientDiagnosis);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public PatientDiagnosisDto GetPatientDiagnosisByID(int id)
        {
            var patientDiagnosis = _patientDiagnosisRepository.GetPatientDiagnosisByID(id);
            return _mapper.Map<PatientDiagnosis, PatientDiagnosisDto>(patientDiagnosis);
        }

        public List<PatientDiagnosisDto> GetPatientDiagnosisByPatientID(int patientID)
        {
            var patientDiagnosises = _patientDiagnosisRepository.GetPatientDiagnosisByPatientID(patientID);
            return _mapper.Map<List<PatientDiagnosis>, List<PatientDiagnosisDto>>(patientDiagnosises);
        }
    }
}
