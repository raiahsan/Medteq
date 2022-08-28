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
using RestSharp;
using Application.Dto.Provider;
using System.Linq;
using Domain.Exceptions;
using Application.Dto.Appointment;
using Application.ServiceInterfaces.IProviderServices;
using Application.RepositoryInterfaces.IGeneralRepositories;
using Application.RepositoryInterfaces.IProviderRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;

namespace Application.Services.ProviderServices
{
    public class ProviderService : IProviderService
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IProviderAvailabilityRepository _providerAvailabilityRepository;
        private readonly IProviderUnavailabilityRepository _providerUnavailabilityRepository;
        private readonly Dictionary<string, string> statePostalCodes = new Dictionary<string, string>()
        {
            {"AL","35004-36925"},
            {"AK","99501-99950"},
            {"AZ","85001-86556"},
            {"AR","71601-72959"},
            {"CA","90001-96162"},
            {"CO","80001-81658"},
            {"CT","06001-06928"},
            {"DE","19701-19980"},
            {"FL","32003-34997"},
            {"GA","30002-39901"},
            {"HI","96701-96898"},
            {"ID","83201-83877"},
            {"IL","60001-62999"},
            {"IN","46001-47997"},
            {"IA","50001-52809"},
            {"KS","66002-67954"},
            {"KY","40003-42788"},
            {"LA","70001-71497"},
            {"ME","03901-04992"},
            {"MD","20588-21930"},
            {"MA","01001-05544"},
            {"MI","48001-49971"},
            {"MN","55001-56763"},
            {"MS","38601-39776"},
            {"MO","63001-65899"},
            {"MT","59001-59937"},
            {"NE","68001-69367"},
            {"NV","88901-89883"},
            {"NH","03031-03897"},
            {"NJ","07001-08989"},
            {"NM","87001-88439"},
            {"NY","00501-14925"},
            {"NC","27006-28909"},
            {"ND","58001-58856"},
            {"OH","43001-45999"},
            {"OK","73001-74966"},
            {"OR","97001-97920"},
            {"PA","15001-19640"},
            {"RI","02801-02940"},
            {"SC","29001-29945"},
            {"SD","57001-57799"},
            {"TN","37010-38589"},
            {"TX","73301-88595"},
            {"UT","84001-84791"},
            {"VT","05001-05907"},
            {"VA","20101-24658"},
            {"WA","98001-99403"},
            {"WV","24701-26886"},
            {"WI","53001-54990"},
            {"WY","82001-83414"}
        };
        public ProviderService(
            IMapper mapper,
            IStateRepository stateRepository,
            IProviderRepository providerRepository,
            IProviderAvailabilityRepository providerAvailabilityRepository,
            IProviderUnavailabilityRepository providerUnavailabilityRepository)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
            _providerRepository = providerRepository;
            _providerAvailabilityRepository = providerAvailabilityRepository;
            _providerUnavailabilityRepository = providerUnavailabilityRepository;
        }
        public bool UpdateProviderList()
        {
            List<ProviderAPIRecords> totalRecords = new List<ProviderAPIRecords>();
            foreach (var item in statePostalCodes)
            {
                if (item.Key == "CA")
                {
                    var postalCode = item.Value.Split("-");
                    for (int i = Convert.ToInt32(postalCode[0]); i <= Convert.ToInt32(postalCode[1]); i++)
                    {
                        if (i != 90001)
                        {
                            break;
                        }
                        bool getRecords = true;
                        List<ProviderAPIRecords> postalCodeRecords = new List<ProviderAPIRecords>();
                        while (getRecords)
                        {
                            var response = GetProviderList<ProviderAPIResponse>(postalCodeRecords.Count, item.Key, i.ToString());
                            if (response?.ResultCount > 0)
                            {
                                postalCodeRecords.AddRange(response.Results);
                            }
                            else
                            {
                                getRecords = false;
                            }
                        }
                        totalRecords.AddRange(postalCodeRecords);
                    }
                }
            }
            var providerListInDB = _providerRepository.GetMany(c => c.Active).ToList();
            var providersAddList = new List<Provider>();
            foreach (var item in totalRecords)
            {
                Provider provider = providerListInDB.FirstOrDefault(c => c.NPINumber == item.Number.ToString());
                var practiceLocationAddress = item.Addresses?.FirstOrDefault();
                var primaryTaxonomies = item.Taxonomies?.Where(c => c.Primary).FirstOrDefault();
                if (provider == null)
                {
                    provider = new Provider();
                    provider.ProviderHubID = Guid.NewGuid();
                    providersAddList.Add(provider);
                }
                provider.Address1 = practiceLocationAddress?.Address1;
                provider.Address2 = practiceLocationAddress?.Address2;
                provider.City = practiceLocationAddress?.City;
                provider.State = practiceLocationAddress?.State;
                provider.PostalCode = practiceLocationAddress?.PostalCode.Substring(0, 5);
                provider.Active = true;
                provider.NPINumber = item?.Number.ToString();
                provider.TaxonomyCode = primaryTaxonomies?.Code;
                provider.FirstName = item?.Basic?.FirstName;
                provider.MiddleName = item?.Basic?.MiddleName;
                provider.LastName = item?.Basic?.LastName;
                provider.Suffix = item?.Basic?.NameSuffix;
                provider.DoctorGroup = primaryTaxonomies?.Desc;
                provider.Specialty = primaryTaxonomies?.Desc;
                provider.FaxNumber = practiceLocationAddress?.FaxNumber.RemoveSpecialCharacters();
            }
            _providerRepository.AddRange(providersAddList);
            _providerRepository.Complete();
            return true;
        }

        private T GetProviderList<T>(int skipRows, string state, string postalCode, int limit = 200)
        {
            var client = new RestClient($"https://npiregistry.cms.hhs.gov/api?state={state}&postal_code={postalCode}&country_code=US&limit={limit}&skip={skipRows}&pretty=on&version=2.1");
            var request = new RestRequest("", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<T>(response.Content);
                return content;
            }
            else
            {
                return default(T);
                //throw new Exception(response.Content);
            }
        }
        #region Provider Availability Unavailability
        public ProviderAvailability UpsertProviderAvailability(UpsertProviderAvailabilityDto providerAvailabilityDto)
        {
            try
            {
                ProviderAvailability providerAvailability = null;
                Provider provider = _providerRepository.GetActiveProvider(providerAvailabilityDto.ProviderID);
                var providerAvailabilitiesInDb = _providerAvailabilityRepository.GetMany(x => x.fk_ProviderID == providerAvailabilityDto.ProviderID && x.DayOfWeek == providerAvailabilityDto.DayOfWeek.GetHashCode() && !x.Deleted);
                if (provider == null)
                {
                    throw new BadRequestException($"Provider with ID '{providerAvailabilityDto.ProviderID}' not found");
                }
                else
                {
                    var fromTime = new TimeSpan(providerAvailabilityDto.FromTime.TimeOfDay.Hours, providerAvailabilityDto.FromTime.TimeOfDay.Minutes, 0);
                    var toTime = new TimeSpan(providerAvailabilityDto.ToTime.TimeOfDay.Hours, providerAvailabilityDto.ToTime.TimeOfDay.Minutes, 0);
                    if (providerAvailabilityDto.ID == 0)
                    {
                        if (providerAvailabilitiesInDb.Any(x => x.FromTime < toTime && fromTime < x.ToTime))
                        {
                            throw new BadRequestException("Time Already Exist");
                        }
                        providerAvailability = new ProviderAvailability
                        {
                            fk_ProviderID = providerAvailabilityDto.ProviderID,
                            FromTime = fromTime,
                            ToTime = toTime,
                            DayOfWeek = (int)providerAvailabilityDto.DayOfWeek,
                            Deleted = false
                        };
                        _providerAvailabilityRepository.Add(providerAvailability);
                    }
                    else
                    {
                        providerAvailability = _providerAvailabilityRepository.GetFirst(x => x.ID == providerAvailabilityDto.ID && !x.Deleted);
                        if (providerAvailability != null)
                        {
                            if ((providerAvailability.ToTime != toTime || providerAvailability.FromTime != fromTime || providerAvailability.DayOfWeek != providerAvailabilityDto.DayOfWeek.GetHashCode()) && providerAvailabilitiesInDb.Any(x => x.FromTime < toTime && fromTime < x.ToTime && x.ID != providerAvailability.ID))
                            {
                                throw new BadRequestException("Time Already Exist");
                            }
                            providerAvailability.fk_ProviderID = providerAvailabilityDto.ProviderID;
                            providerAvailability.FromTime = fromTime;
                            providerAvailability.ToTime = toTime;
                            providerAvailability.DayOfWeek = (int)providerAvailabilityDto.DayOfWeek;
                            providerAvailability.Deleted = false;
                            _providerAvailabilityRepository.Update(providerAvailability);
                        }
                        else
                        {
                            throw new BadRequestException($"ProviderAvailability with ID '{providerAvailabilityDto.ID}' not found");
                        }
                    }
                }
                _providerAvailabilityRepository.Complete();
                return providerAvailability;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        public ProviderUnavailability UpsertProviderUnavailability(UpsertProviderUnvailabilityDto providerUnvailabilityDto)
        {
            try
            {
                ProviderUnavailability providerUnavailability = null;
                Provider provider = _providerRepository.GetActiveProvider(providerUnvailabilityDto.ProviderID);
                var providerUnavailabilitiesInDb = _providerUnavailabilityRepository.GetMany(x => x.fk_ProviderID == providerUnvailabilityDto.ProviderID && !x.Deleted);
                if (provider == null)
                {
                    throw new BadRequestException($"Provider with ID '{providerUnvailabilityDto.ProviderID}' not found");
                }
                else
                {
                    if (providerUnvailabilityDto.ID == 0)
                    {
                        if (providerUnavailabilitiesInDb.Any(x => x.FromDateTime < providerUnvailabilityDto.ToDateTime && providerUnvailabilityDto.FromDateTime < x.ToDateTime))
                        {
                            throw new BadRequestException("Time Already Exist");
                        }
                        providerUnavailability = new ProviderUnavailability
                        {
                            fk_ProviderID = providerUnvailabilityDto.ProviderID,
                            ToDateTime = providerUnvailabilityDto.ToDateTime,
                            FromDateTime = providerUnvailabilityDto.FromDateTime,
                            Deleted = false
                        };
                        _providerUnavailabilityRepository.Add(providerUnavailability);
                    }
                    else
                    {
                        providerUnavailability = _providerUnavailabilityRepository.GetFirst(x => x.ID == providerUnvailabilityDto.ID && !x.Deleted);
                        if (providerUnavailability != null)
                        {
                            if ((providerUnavailability.ToDateTime != providerUnvailabilityDto.ToDateTime || providerUnavailability.FromDateTime != providerUnvailabilityDto.FromDateTime) && providerUnavailabilitiesInDb.Any(x => x.FromDateTime < providerUnvailabilityDto.ToDateTime && providerUnvailabilityDto.FromDateTime < x.ToDateTime && x.ID != providerUnavailability.ID))
                            {
                                throw new BadRequestException("Time Already Exist");
                            }
                            providerUnavailability.fk_ProviderID = providerUnvailabilityDto.ProviderID;
                            providerUnavailability.ToDateTime = providerUnvailabilityDto.ToDateTime;
                            providerUnavailability.FromDateTime = providerUnvailabilityDto.FromDateTime;
                            providerUnavailability.Deleted = false;
                            _providerUnavailabilityRepository.Update(providerUnavailability);
                        }
                        else
                        {
                            throw new BadRequestException($"ProviderUnvailability with ID '{providerUnvailabilityDto.ID}' not found");
                        }
                    }
                }
                _providerUnavailabilityRepository.Complete();
                return providerUnavailability;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<ProviderAvailabilityDto> GetAvailabilitiesByProviderID(int providerID)
        {
            var availabilities = _providerRepository.GetAvailabilitiesByProviderID(providerID);
            return _mapper.Map<List<ProviderAvailability>, List<ProviderAvailabilityDto>>(availabilities);
        }
        public List<ProviderUnavailabilityDto> GetUnavailabilitiesByProviderID(int providerID)
        {
            var unavailabilities = _providerRepository.GetUnavailabilitiesByProviderID(providerID);
            return _mapper.Map<List<ProviderUnavailability>, List<ProviderUnavailabilityDto>>(unavailabilities);
        }

        public ProviderUnavailabilityDto DeleteProviderUnavailability(int id)
        {
            try
            {
                ProviderUnavailability providerUnavailability = _providerUnavailabilityRepository.GetFirst(c => c.ID == id && !c.Deleted);
                if (providerUnavailability != null)
                {
                    providerUnavailability.Deleted = true;
                    _providerUnavailabilityRepository.Complete();
                }
                else
                {
                    throw new BadRequestException($"ProviderUnavailability '{id}' not found");
                }
                return _mapper.Map<ProviderUnavailabilityDto>(providerUnavailability);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ProviderAvailabilityDto DeleteProviderAvailability(int id)
        {
            try
            {
                ProviderAvailability providerAvailability = _providerAvailabilityRepository.GetFirst(c => c.ID == id && !c.Deleted);
                if (providerAvailability != null)
                {
                    providerAvailability.Deleted = true;
                    _providerUnavailabilityRepository.Complete();
                }
                else
                {
                    throw new BadRequestException($"ProviderUnavailability '{id}' not found");
                }
                return _mapper.Map<ProviderAvailabilityDto>(providerAvailability);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public GetProviderDto GetProviderByID(int providerID)
        {
            var provider = _providerRepository.GetProviderByID(providerID);
            return _mapper.Map<Provider, GetProviderDto>(provider);
        }

        public GetProviderDto GetProviderByNPINumber(int npiNumber)
        {
            var providerNpiNumber = _providerRepository.GetProviderByNPINumber(npiNumber);
            return _mapper.Map<Provider, GetProviderDto>(providerNpiNumber);
        }

        public List<GetProviderDto> GetProviders()
        {
            var providers = _providerRepository.GetAllProviders();
            return _mapper.Map<List<Provider>, List<GetProviderDto>>(providers);
        }

        public List<GetProviderDto> GetProviders(ProviderSearchDto providerSearchDto)
        {
            try
            {
                var providers = _providerRepository.GetProviders(providerSearchDto);
                return _mapper.Map<List<Provider>, List<GetProviderDto>>(providers);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}