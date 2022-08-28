using Application.Configurations;
using Application.Dto.Provider;
using Application.General.Dto;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IProviderRepositories;
using AutoMapper;
using Domain.Constants;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories.ProviderRepositories
{
    class ProviderRepository : GenericRepository<Provider>, IProviderRepository
    {
        private readonly string _connectionString;
        public ProviderRepository(AppDbContext context, IConfiguration configuration) : base(context)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool DeleteDuplicateNPINumbers()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(@"WITH DuplicateProviders([ID],[NPINumber],DuplicateCount)
                        AS(SELECT ID, NPINumber, ROW_NUMBER() OVER(PARTITION BY[NPINumber] ORDER BY CreatedDate DESC) AS DuplicateCount FROM[Provider])
 DELETE FROM DuplicateProviders WHERE DuplicateCount > 1; ", connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
        #region Provider
        public Provider GetActiveProvider(int id)
        {
            return _context.Providers.Where(c => c.ID == id && c.Active).FirstOrDefault();
        }

        public List<Provider> GetAllProviders(bool? active = null)
        {
            return _context.Providers.Where(c => !active.HasValue || c.Active == active.Value).ToList();
        }
        #endregion
        #region Provider Availability Unavailability
        public List<ProviderAvailability> GetAvailabilitiesByProviderID(int providerID)
        {
            return _context.ProviderAvailabilities.Where(c => c.fk_ProviderID == providerID && !c.Deleted).ToList();
        }

        public Provider GetProviderByID(int providerID)
        {
            return _context.Providers
               .Include(c => c.ParentProvider)
               .Where(c => c.ID == providerID && c.Active).FirstOrDefault();
        }

        public Provider GetProviderByNPINumber(int npiNumber)
        {
            return _context.Providers.Where(c => c.NPINumber == Convert.ToString(npiNumber) && c.Active).FirstOrDefault();
        }

        public List<ProviderUnavailability> GetUnavailabilitiesByProviderID(int providerID)
        {
            return _context.ProviderUnavailabilities.Where(c => c.fk_ProviderID == providerID && !c.Deleted).ToList();
        }

        public List<Provider> GetProviders(ProviderSearchDto providerSearchDto)
        {
            var providers = _context.Providers
                .Where(c => (string.IsNullOrWhiteSpace(providerSearchDto.FirstName) || c.FirstName == providerSearchDto.FirstName)
                && (string.IsNullOrWhiteSpace(providerSearchDto.LastName) || c.LastName == providerSearchDto.LastName)
                && (string.IsNullOrWhiteSpace(providerSearchDto.Email) || c.EmailAddress == providerSearchDto.Email)
                && (!providerSearchDto.ProviderID.HasValue || c.ID == providerSearchDto.ProviderID)
                && (c.NPINumber == providerSearchDto.NPINumber)
                && c.Active)
                .OrderBy(c => c.ID == providerSearchDto.ProviderID)
                .ToList();
            return providers;
        }
    }
    #endregion
}

