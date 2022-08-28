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
using Application.Dto.PatientPayor;
using Application.ExternalDependencies;
using Application.Dto.PVerify.EligibilitySummaryResponse;
using Application.Dto.PVerify;
using Domain.Exceptions;
using Application.ServiceInterfaces.IPatientServices;
using Application.RepositoryInterfaces.IGeneralRepositories;
using Application.RepositoryInterfaces.IPatientRepositories;
using Application.RepositoryInterfaces.IProviderRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;

namespace Application.Services.PatientServices
{
    public class PatientPayorService : IPatientPayorService
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly IStateRepository _stateRepository;
        private readonly IPayorLevelRepository _payorLevelRepository;
        private readonly IPatientPayorRepository _patientPayorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IPayorRepository _payorRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IPatientPayorEligibilityRepository _patientPayorEligibilityRepository;
        private readonly IEligibilityAPIHandler _eligibilityAPIHandler;

        public PatientPayorService(
            IMapper mapper,
            IGenderRepository genderRepository,
            IStateRepository stateRepository,
            IPatientPayorRepository patientPayorRepository,
            IPayorLevelRepository payorLevelRepository,
            IPatientRepository patientRepository,
            IPayorRepository payorRepository,
            IPatientPayorEligibilityRepository patientPayorEligibilityRepository,
            IEligibilityAPIHandler eligibilityAPIHandler,
             IProviderRepository providerRepository
            )
        {
            _genderRepository = genderRepository;
            _stateRepository = stateRepository;
            _patientPayorRepository = patientPayorRepository;
            _payorLevelRepository = payorLevelRepository;
            _patientRepository = patientRepository;
            _payorRepository = payorRepository;
            _patientPayorEligibilityRepository = patientPayorEligibilityRepository;
            _eligibilityAPIHandler = eligibilityAPIHandler;
            _providerRepository = providerRepository;
            _mapper = mapper;
        }
        public async Task<PatientPayor> UpsertPatientPayor(CreatePatientPayorDto patientPayorDto)
        {
            try
            {
                PatientPayor patientPayor = null;
                Patient patient = _patientRepository.GetFirst(c => c.ID == patientPayorDto.PatientID);
                Payor payor = _payorRepository.GetFirst(c => c.ID == patientPayorDto.PayorID && c.Active);
                if (patient == null)
                {
                    throw new BadRequestException($"Patient with ID '{patientPayorDto.PatientID}' not found");
                }
                else if (payor == null)
                {
                    throw new BadRequestException($"Payor with ID '{patientPayorDto.PayorID}' not found");
                }
                else
                {
                    if (patientPayorDto.ID == 0)
                    {
                        patientPayor = new PatientPayor
                        {
                            PatientPayorGUID = Guid.NewGuid(),
                            fk_PolicyHolderGenderID = _genderRepository.GetGender(patientPayorDto.PolicyHolderGender)?.ID,
                            Active = true,
                            Bin = patientPayorDto.Bin,
                            Deductible = patientPayorDto.Deductible,
                            Deleted = false,
                            fk_PatientID = patient.ID,
                            fk_PayorLevelID = _payorLevelRepository.GetPayorLevel(patientPayorDto.PayorLevel)?.ID ?? 0,
                            fk_PayorID = payor.ID,
                            GroupName = patientPayorDto.GroupName,
                            GroupNumber = patientPayorDto.GroupNumber,
                            InsuredAddress1 = patientPayorDto.InsuredAddress1,
                            InsuredAddress2 = patientPayorDto.InsuredAddress2,
                            InsuredCity = patientPayorDto.InsuredCity,
                            fk_InsuredStateID = _stateRepository.GetState(patientPayorDto.InsuredState)?.ID,
                            InsuredFirstName = patientPayorDto.InsuredFirstName,
                            InsuredLastName = patientPayorDto.InsuredLastName,
                            InsuredPhone = patientPayorDto.InsuredPhone.RemoveSpecialCharacters(),
                            InsuredZip = patientPayorDto.InsuredZip,
                            InsVerified = patientPayorDto.InsVerified,
                            InsVerifiedBy = patientPayorDto.InsVerifiedBy,
                            InsVerifiedDate = patientPayorDto.InsVerifiedDate,
                            NCDPDPolicyNumber = patientPayorDto.NCDPDPolicyNumber,
                            NCPDPGroupNumber = patientPayorDto.NCPDPGroupNumber,
                            PayorContact = patientPayorDto.PayorContact,
                            PayPercent = patientPayorDto.PayPercent,
                            Pcn = patientPayorDto.Pcn,
                            PolicyStartDate = patientPayorDto.PolicyStartDate,
                            PolicyEndDate = patientPayorDto.PolicyEndDate,
                            VerificationType = patientPayorDto.VerificationType,
                            PolicyNumber = patientPayorDto.PolicyNumber,
                            PolicyHolderName = patientPayorDto.PolicyHolderName,
                            PolicyHolderDOB = patientPayorDto.PolicyHolderDOB,
                            RawData = JsonConvert.SerializeObject(patientPayorDto)
                        };
                        await _patientPayorRepository.Add(patientPayor);
                    }
                    else
                    {
                        patientPayor = _patientPayorRepository.GetPatientPayorWithDetails(patientPayorDto.ID);
                        if (patientPayor != null)
                        {
                            patientPayor.fk_PolicyHolderGenderID = _genderRepository.GetGender(patientPayorDto.PolicyHolderGender)?.ID;
                            patientPayor.Active = true;
                            patientPayor.Bin = patientPayorDto.Bin;
                            patientPayor.Deductible = patientPayorDto.Deductible;
                            patientPayor.Deleted = false;
                            patientPayor.fk_PatientID = patient.ID;
                            patientPayor.fk_PayorLevelID = _payorLevelRepository.GetPayorLevel(patientPayorDto.PayorLevel)?.ID ?? 0;
                            patientPayor.fk_PayorID = payor.ID;
                            patientPayor.GroupName = patientPayorDto.GroupName;
                            patientPayor.GroupNumber = patientPayorDto.GroupNumber;
                            patientPayor.InsuredAddress1 = patientPayorDto.InsuredAddress1;
                            patientPayor.InsuredAddress2 = patientPayorDto.InsuredAddress2;
                            patientPayor.InsuredCity = patientPayorDto.InsuredCity;
                            patientPayor.fk_InsuredStateID = _stateRepository.GetState(patientPayorDto.InsuredState)?.ID;
                            patientPayor.InsuredFirstName = patientPayorDto.InsuredFirstName;
                            patientPayor.InsuredLastName = patientPayorDto.InsuredLastName;
                            patientPayor.InsuredPhone = patientPayorDto.InsuredPhone.RemoveSpecialCharacters();
                            patientPayor.InsuredZip = patientPayorDto.InsuredZip;
                            patientPayor.InsVerified = patientPayorDto.InsVerified;
                            patientPayor.InsVerifiedBy = patientPayorDto.InsVerifiedBy;
                            patientPayor.InsVerifiedDate = patientPayorDto.InsVerifiedDate;
                            patientPayor.NCDPDPolicyNumber = patientPayorDto.NCDPDPolicyNumber;
                            patientPayor.NCPDPGroupNumber = patientPayorDto.NCPDPGroupNumber;
                            patientPayor.PayorContact = patientPayorDto.PayorContact;
                            patientPayor.PayPercent = patientPayorDto.PayPercent;
                            patientPayor.Pcn = patientPayorDto.Pcn;
                            patientPayor.PolicyStartDate = patientPayorDto.PolicyStartDate;
                            patientPayor.PolicyEndDate = patientPayorDto.PolicyEndDate;
                            patientPayor.VerificationType = patientPayorDto.VerificationType;
                            patientPayor.PolicyNumber = patientPayorDto.PolicyNumber;
                            patientPayor.PolicyHolderName = patientPayorDto.PolicyHolderName;
                            patientPayor.PolicyHolderDOB = patientPayorDto.PolicyHolderDOB;
                            patientPayor.RawData = JsonConvert.SerializeObject(patientPayorDto);
                            _patientPayorRepository.Update(patientPayor);
                        }
                    }
                    _patientPayorRepository.Complete();
                    return patientPayor;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PatientPayorEligibility> CheckPatientPayorEligibilityAsync(CheckPatientPayorEligibilityDto eligibilityDto)
        {
            try
            {
                PatientPayor patientPayor = _patientPayorRepository.GetPatientPayorWithDetails(eligibilityDto.PatientPayorID);
                Provider provider = _providerRepository.GetFirst(c => c.NPINumber == eligibilityDto.ProviderNPI && c.Active);
                if (patientPayor == null)
                {
                    throw new BadRequestException($"PatientPayor with ID '{eligibilityDto.PatientPayorID}' not found");
                }
                else if (provider == null)
                {
                    throw new BadRequestException($"Provider with NPI number '{eligibilityDto.ProviderNPI}' not found");
                }
                else
                {
                    var response = _eligibilityAPIHandler.CheckEligibilitySummary(patientPayor, provider);
                    EligibilitySummaryResponse eligibilityApiResponse = JSONSerializerHelper.Deserialize<EligibilitySummaryResponse>(response);
                    if (eligibilityApiResponse.APIResponseCode == PVerifyAPIResponseCode.Processed.ToString())
                    {
                        //var patientPayorEligibility = new PatientPayorEligibility
                        //{
                        //    EligibilityGUID = Guid.NewGuid(),
                        //    fk_PatientID = patientPayor.fk_PatientID,
                        //    Fk_PatientPayorID = patientPayor.ID,
                        //    BatchName = eligibilityDto.BatchName,
                        //    DateOfServiceFrom = eligibilityDto.DateOfServiceFrom,
                        //    DateOfServiceTo = eligibilityDto.DateOfServiceTo,
                        //    DependentFirstName = eligibilityDto.DependentFirstName,
                        //    DependentLastName = eligibilityDto.DependentLastName,
                        //    DependentRelationship = eligibilityDto.DependentRelationship,
                        //    IssueDate = eligibilityDto.IssueDate,
                        //    Manual = eligibilityDto.Manual,
                        //    Notes = eligibilityDto.Notes,
                        //    PatientDOB = patient.DOB.ToString(),
                        //    PatientGender = patient.Gender?.Value,
                        //    ProviderFirstName = eligibilityDto.ProviderFirstName,
                        //    ProviderLastName = eligibilityDto.ProviderLastName,
                        //    ProviderNPI = eligibilityDto.ProviderNPI,
                        //    ProviderPIN = eligibilityDto.ProviderPIN,
                        //    ServiceCodes = eligibilityDto.ServiceCodes,
                        //    SubcriberFirstName = eligibilityDto.SubcriberFirstName,
                        //    SubcriberLastName = eligibilityDto.SubcriberLastName,
                        //    SubcriberMemberID = eligibilityDto.SubcriberMemberID,
                        //    SubcriberSSN = eligibilityDto.SubcriberSSN?.RemoveSpecialCharacters(),
                        //    SubscriberGroupNumber = eligibilityDto.SubscriberGroupNumber,

                        //};
                        //await _patientPayorEligibilityRepository.Add(patientPayorEligibility);
                    }
                    //_patientRepository.Complete();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GetPatientPayorDto> GetPatientPayorsByPatientID(int patientID)
        {
            var patientPayor = _patientPayorRepository.GetPatientPayorsByPatientID(patientID);
            return _mapper.Map<List<PatientPayor>, List<GetPatientPayorDto>>(patientPayor);
        }

        public GetPatientPayorDto DeletePatientPayor(int id)
        {
            try
            {
                PatientPayor patientPayor = _patientPayorRepository.GetFirst(c => c.ID == id && !c.Deleted && c.Active);
                if (patientPayor != null)
                {
                    patientPayor.Deleted = true;
                    patientPayor.Active = false;
                    _patientPayorRepository.Complete();
                }
                else
                {
                    throw new BadRequestException($"PatientPayor '{id}' not found");
                }
                return _mapper.Map<GetPatientPayorDto>(patientPayor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public GetPatientPayorDto GetPatientPayorByID(int id)
        {
            var patientPayor = _patientPayorRepository.GetPatientPayorByID(id);
            return _mapper.Map<PatientPayor, GetPatientPayorDto>(patientPayor);
        }
    }
}
