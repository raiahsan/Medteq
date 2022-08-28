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
    class ICDCodeTypeRepository : GenericRepository<ICDCodeType>, IICDCodeTypeRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public ICDCodeTypeRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }
        public List<ICDCodeType> GetAllICDCodeTypes(bool? active = null)
        {
            if (!_memoryCache.TryGetValue(CacheKey.ICDCodeTypes, out List<ICDCodeType> codeTypes))
            {
                codeTypes = _context.ICDCodeTypes.AsNoTracking().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.ICDCodeTypes, codeTypes, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<ICDCodeType>>(codeTypes.Where(c => !active.HasValue || c.Active == active.Value).ToList());
        }

        public ICDCodeType GetICDCodeType(string name)
        {
            return GetAllICDCodeTypes(true).Where(c => String.Compare(name, c.TypeName, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }
    }
}
