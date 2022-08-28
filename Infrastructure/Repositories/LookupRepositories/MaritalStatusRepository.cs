using Application.Configurations;
using Application.Dto.General;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.ILookupRepositories;
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

namespace Infrastructure.Repositories.LookupRepositories
{
    class MaritalStatusRepository : GenericRepository<MaritalStatus>, IMaritalStatusRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public MaritalStatusRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }
        public List<MaritalStatus> GetAllMaritalStatuses(bool? active = null)
        {
            if (!_memoryCache.TryGetValue(CacheKey.MaritalStatuses, out List<MaritalStatus> maritalStatuses))
            {
                maritalStatuses = _context.MaritalStatuses.AsNoTracking().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.MaritalStatuses, maritalStatuses, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<MaritalStatus>>(maritalStatuses.Where(c => !active.HasValue || c.Active == active.Value).ToList());
        }

        public MaritalStatus GetMaritalStatus(string name)
        {
            return GetAllMaritalStatuses(true).Where(c => String.Compare(name, c.Value, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }
    }
}
