using Application.Dto.Patient;
using Application.Dto.Provider;
using Application.General.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RepositoryInterfaces.IProviderRepositories
{
    public interface IProviderRepository : IGenericRepository<Provider>
    {
        bool DeleteDuplicateNPINumbers();
        #region Provider
        Provider GetActiveProvider(int id);
        #endregion
        #region Provider Availability Unavailability
        List<ProviderAvailability> GetAvailabilitiesByProviderID(int providerID);
        List<ProviderUnavailability> GetUnavailabilitiesByProviderID(int providerID);
        List<Provider> GetAllProviders(bool? active = null);
        Provider GetProviderByID(int providerID);
        Provider GetProviderByNPINumber(int npiNumber);
        List<Provider> GetProviders(ProviderSearchDto providerSearchDto);
        #endregion
    }
}
