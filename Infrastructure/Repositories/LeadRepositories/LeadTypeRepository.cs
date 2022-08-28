using Application.Configurations;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.ILeadRepositories;
using Domain.Constants;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories.LeadRepositories
{
    class LeadTypeRepository : GenericRepository<LeadType>, ILeadTypeRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public LeadTypeRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }

        public List<LeadType> GetAllLeadTypes(bool? active = null)
        {
            if (!_memoryCache.TryGetValue(CacheKey.LeadTypes, out List<LeadType> leadTypes))
            {
                leadTypes = _context.LeadTypes.AsNoTracking().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.LeadTypes, leadTypes, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<LeadType>>(leadTypes.Where(c => !active.HasValue || c.Active == active.Value).ToList());
        }

        public LeadType GetLeadType(string name)
        {
            return GetAllLeadTypes(true).Where(c => String.Compare(name, c.Name, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }
    }
}
