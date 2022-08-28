using Application.Configurations;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IProviderRepositories;
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
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ProviderRepositories
{
    class ProviderTypeRepository : GenericRepository<ProviderType>, IProviderTypeRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public ProviderTypeRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }
        public List<ProviderType> GetAllProviderTypes(bool? active = null)
        {
            if (!_memoryCache.TryGetValue(CacheKey.ProviderType, out List<ProviderType> providerTypes))
            {
                providerTypes = _context.ProviderTypes.AsNoTracking().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.ProviderType, providerTypes, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<ProviderType>>(providerTypes.Where(c => !active.HasValue || c.Active == active.Value).ToList());
        }
        public ProviderType GetProviderType(int ID)
        {
            return GetAllProviderTypes(true).Where(c => ID == c.ID).FirstOrDefault();
        }
        public ProviderType GetProviderType(string name)
        {
            return GetAllProviderTypes(true).Where(c => String.Compare(name, c.Type, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }
    }
}
