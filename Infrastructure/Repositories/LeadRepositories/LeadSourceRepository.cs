using Application.Configurations;
using Application.Dto.General;
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
    class LeadSourceRepository : GenericRepository<LeadSource>, ILeadSourceRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public LeadSourceRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }

        public List<LeadSource> GetAllLeadSources(bool? active = null)
        {
            if (!_memoryCache.TryGetValue(CacheKey.LeadSources, out List<LeadSource> leadSources))
            {
                leadSources = _context.LeadSources.AsNoTracking().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.LeadSources, leadSources, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<LeadSource>>(leadSources.Where(c => !active.HasValue || c.Active == active.Value).ToList());
        }

        public LeadSource GetLeadSource(string name)
        {
            return GetAllLeadSources(true).Where(c => String.Compare(name, c.Name, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }

    }
}
