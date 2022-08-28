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
using Application.Helper;
using Domain.Exceptions;
using Application.ServiceInterfaces.ILeadServices;
using Application.RepositoryInterfaces.ILeadRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;
using Application.RepositoryInterfaces.IPatientRepositories;
using Application.General.Dto;

namespace Application.Services.LeadServices
{
    public class LeadService : ILeadService
    {
        private readonly IMapper _mapper;
        private readonly ILeadRepository _leadRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IStateRepository _stateRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly ILeadSourceRepository _leadSourceRepository;
        private readonly ILeadTypeRepository _leadTypeRepository;
        private readonly IContactMethodRepository _contactMethodRepository;
        private readonly ILeadContactRepository _leadContactRepository;
        private readonly IPatientRepository _patientRepository;

        public LeadService(
            ILeadRepository leadRepository,
            IMapper mapper,
            IBranchRepository branchRepository,
            IStateRepository stateRepository,
            IGenderRepository genderRepository,
            ILeadSourceRepository leadSourceRepository,
            ILeadTypeRepository leadTypeRepository,
            IContactMethodRepository contactMethodRepository,
            ILeadContactRepository leadContactRepository,
            IPatientRepository patientRepository)
        {
            _leadRepository = leadRepository;
            _branchRepository = branchRepository;
            _mapper = mapper;
            _stateRepository = stateRepository;
            _leadTypeRepository = leadTypeRepository;
            _leadSourceRepository = leadSourceRepository;
            _genderRepository = genderRepository;
            _contactMethodRepository = contactMethodRepository;
            _leadContactRepository = leadContactRepository;
            _patientRepository = patientRepository;
        }
        public async Task<Lead> UpsertLead(CreateLeadDto leadDto)
        {
            try
            {
                var branch = _branchRepository.GetFirst(c => c.Active && String.Compare(c.BranchName, leadDto.Branch, StringComparison.OrdinalIgnoreCase) == 0);
                if (branch == null)
                {
                    throw new BadRequestException($"Branch '{leadDto.Branch}' not found");
                }
                else
                {
                    Lead lead = null;
                    if (leadDto.ID == 0)
                    {
                        lead = new Lead();
                        lead.LeadGUID = Guid.NewGuid();
                        await _leadRepository.Add(lead);
                    }
                    else
                    {
                        lead = _leadRepository.GetLeadById(leadDto.ID);
                        if (lead == null)
                        {
                            throw new BadRequestException($"Lead '{leadDto.ID}' not found");
                        }
                    }
                    var patient = _patientRepository.GetFirst(c => c.FirstName == leadDto.FirstName && c.LastName == leadDto.LastName && c.DOB == leadDto.DOB);

                    lead.fk_GenderID = _genderRepository.GetGender(leadDto.Gender)?.ID;
                    lead.fk_LeadSourceID = _leadSourceRepository.GetLeadSource(leadDto.LeadSource)?.ID ?? 0;
                    lead.fk_LeadTypeID = _leadTypeRepository.GetLeadType(leadDto.LeadType)?.ID ?? 0;
                    lead.BillingAddress1 = leadDto.BillingAddress1;
                    lead.BillingAddress2 = leadDto.BillingAddress2;
                    lead.BillingAddress3 = leadDto.BillingAddress3;
                    lead.BillingCity = leadDto.BillingCity;
                    lead.fk_BillingStateID = _stateRepository.GetState(leadDto.BillingState)?.ID ?? null;
                    lead.BillingPostalCode = leadDto.BillingPostalCode;
                    lead.MobilePhone = leadDto.MobilePhone.RemoveSpecialCharacters();
                    lead.LastName = leadDto.LastName;
                    lead.FirstName = leadDto.FirstName;
                    lead.fk_PatientID = patient?.ID;
                    lead.fk_BranchID = branch.ID;
                    lead.DOB = leadDto.DOB.Date;
                    lead.DateLastSeenByDoctor = leadDto.DateLastSeenByDoctor;
                    lead.DiagnosisCode = leadDto.DiagnosisCode;
                    lead.DoctorFirstName = leadDto.DoctorFirstName;
                    lead.DoctorLastName = leadDto.DoctorLastName;
                    lead.DoctorNPI = leadDto.DoctorNPI;
                    lead.Notes = leadDto.Notes;
                    lead.HomePhone = leadDto.HomePhone.RemoveSpecialCharacters();
                    lead.Email = leadDto.Email;
                    lead.LeadRawData = JsonConvert.SerializeObject(leadDto);
                    _leadContactRepository.Delete(c => c.fk_LeadID == lead.ID);
                    lead.LeadContacts.Clear();

                    if (leadDto.LeadContacts?.Count > 0)
                    {
                        foreach (var item in leadDto.LeadContacts)
                        {
                            lead.LeadContacts.Add(new LeadContact
                            {
                                Email = item.Email,
                                FaxNumber = item.FaxNumber,
                                IsDefault = item.IsDefault,
                                MobileNumber = item.MobileNumber.RemoveSpecialCharacters(),
                                PhoneNumber = item.PhoneNumber.RemoveSpecialCharacters(),
                                fk_ContactMethodID = _contactMethodRepository.GetContactMethod(item.ContactMethod)?.ID ?? 0
                            });
                        }
                    }
                    _leadRepository.Complete();
                    return lead;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public GetLeadDto GetLeadByID(int id)
        {
            var leads = _leadRepository.GetLeadById(id);
            return _mapper.Map<Lead, GetLeadDto>(leads);
        }

        public RecordSet<GetLeadDto> GetLeads(LeadSearchDto leadSearch)
        {
            try
            {
                return _leadRepository.GetLeads(leadSearch);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
