using Domain.Entities;
using Application.Dto.Lead;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Patient;
using Application.General.Dto;
using Application.Dto.Provider;
using Application.Dto.Appointment;

namespace Application.ServiceInterfaces.IProviderServices
{
    public interface IProviderService
    {
        ProviderAvailability UpsertProviderAvailability(UpsertProviderAvailabilityDto providerAvailabilityDto);
        List<ProviderAvailabilityDto> GetAvailabilitiesByProviderID(int providerID);
        List<ProviderUnavailabilityDto> GetUnavailabilitiesByProviderID(int providerID);
        ProviderUnavailability UpsertProviderUnavailability(UpsertProviderUnvailabilityDto providerUnvailabilityDto);
        ProviderUnavailabilityDto DeleteProviderUnavailability(int id);
        ProviderAvailabilityDto DeleteProviderAvailability(int id);
        GetProviderDto GetProviderByID(int providerID);
        GetProviderDto GetProviderByNPINumber(int npiNumber);
        List<GetProviderDto> GetProviders();
        List<GetProviderDto> GetProviders(ProviderSearchDto providerSearchDto);
        bool UpdateProviderList();
    }

}
