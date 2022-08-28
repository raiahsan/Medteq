using Application.Dto.General;
using Application.Dto.Provider;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IGeneralRepositories;
using Application.RepositoryInterfaces.ILeadRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;
using Application.RepositoryInterfaces.IPatientRepositories;
using Application.RepositoryInterfaces.IProviderRepositories;
using Application.ServiceInterfaces;
using Application.ServiceInterfaces.IGeneralServices;
using Application.ServiceInterfaces.ILookupServices;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.LookupServices
{
    public class LookupService : ILookupService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IAddressTypeRepository _addressTypeRepository;
        private readonly IContactMethodRepository _contactMethodRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly ILeadSourceRepository _leadSourceRepository;
        private readonly IMaritalStatusRepository _maritalStatusRepository;
        private readonly IRelationshipTypeRepository _relationshipTypeRepository;
        private readonly IICDCodeTypeRepository _iCDCodeTypeRepository;
        private readonly IPayorLevelRepository _payorLevelRepository;
        private readonly ILeadTypeRepository _leadTypeRepository;
        private readonly IContactTypeRepository _contactTypeRepository;
        private readonly IProviderTypeRepository _providerTypeRepository;
        private readonly IDiagnosisRepository _diagnosisRepository;
        private readonly IMapper _mapper;
        public LookupService(IStateRepository stateRepository,
            IAddressTypeRepository addressTypeRepository,
            IContactMethodRepository contactMethodRepository,
            IGenderRepository genderRepository,
            ILeadSourceRepository leadSourceRepository,
            IMaritalStatusRepository maritalStatusRepository,
            IRelationshipTypeRepository relationshipTypeRepository,
            IICDCodeTypeRepository iCDCodeTypeRepository,
            IPayorLevelRepository payorLevelRepository,
            ILeadTypeRepository leadTypeRepository,
            IContactTypeRepository contactTypeRepository,
            IProviderTypeRepository providerTypeRepository,
            IDiagnosisRepository diagnosisRepository,
            IMapper mapper)
        {
            _stateRepository = stateRepository;
            _addressTypeRepository = addressTypeRepository;
            _contactMethodRepository = contactMethodRepository;
            _genderRepository = genderRepository;
            _leadSourceRepository = leadSourceRepository;
            _maritalStatusRepository = maritalStatusRepository;
            _relationshipTypeRepository = relationshipTypeRepository;
            _iCDCodeTypeRepository = iCDCodeTypeRepository;
            _payorLevelRepository = payorLevelRepository;
            _leadTypeRepository = leadTypeRepository;
            _contactTypeRepository = contactTypeRepository;
            _providerTypeRepository = providerTypeRepository;
            _diagnosisRepository = diagnosisRepository;
            _mapper = mapper;
        }

        public List<LookupDto> GetAllActiveGenders()
        {
            return _genderRepository.GetAllGenders(true).Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.Value,
            }).ToList();
        }

        public List<LookupDto> GetAllActiveICDCodeTypes()
        {
            return _iCDCodeTypeRepository.GetAllICDCodeTypes(true).Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.TypeName,
            }).ToList();
        }

        public List<LookupDto> GetAllActiveLeadSources()
        {
            return _leadSourceRepository.GetAllLeadSources(true).Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.Name,
            }).ToList(); ;
        }

        public List<LookupDto> GetAllActiveMaritalStatus()
        {
            return _maritalStatusRepository.GetAllMaritalStatuses(true).Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.Value,
            }).ToList();
        }

        public List<LookupDto> GetAllActivePayorLevels()
        {
            return _payorLevelRepository.GetAllPayorLevels(true).Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.Name,
            }).ToList(); ;
        }

        public List<LookupDto> GetAllActiveRelationshipTypes()
        {
            return _relationshipTypeRepository.GetAllRelationshipTypes(true).Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.Type,
            }).ToList(); ;
        }

        public List<LookupDto> GetAllActiveStates()
        {
            return _stateRepository.GetAllStates(true).Select(x => new LookupDto
            {
                Key = x.ID,
                Value = x.Name
            }).ToList();
        }

        public List<LookupDto> GetAllActiveAddressesType()
        {
            return _addressTypeRepository.GetAllAddressTypes(true).Select(x => new LookupDto
            {
                Key = x.ID,
                Value = x.TypeName
            }).ToList();
        }

        public List<LookupDto> GetAllContactsMethod()
        {
            return _contactMethodRepository.GetAllContactMethods(true).Select(x => new LookupDto
            {
                Key = x.ID,
                Value = x.Name
            }).ToList();
        }

        public List<LookupDto> GetAllActiveLeadTypes()
        {
            return _leadTypeRepository.GetAllLeadTypes(true).Select(x => new LookupDto
            {
                Key = x.ID,
                Value = x.Name,

            }).ToList();
        }

        public List<LookupDto> GetAllActiveContactTypes()
        {
            return _contactTypeRepository.GetAllContactTypes(true).Select(x => new LookupDto
            {
                Key = x.ID,
                Value = x.Type,
            }).ToList();
        }

        public List<LookupDto> GetAllActiveProviderTypes()
        {
            return _providerTypeRepository.GetAllProviderTypes(true).Select(x => new LookupDto
            {
                Key = x.ID,
                Value = x.Type,
            }).ToList();
        }

        public List<GetDiagnosisDto> GetAllActiveDiagnosises()
        {
            var daignosises = _diagnosisRepository.GetAllDiagnosises(true);
            return _mapper.Map<List<Diagnosis>, List<GetDiagnosisDto>>(daignosises);
        }
    }
}
