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
    class AddressTypeRepository : GenericRepository<AddressType>, IAddressTypeRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public AddressTypeRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }

        public List<AddressType> GetAllAddressTypes(bool? active = null)
        {
            if (!_memoryCache.TryGetValue(CacheKey.AddressTypes, out List<AddressType> addressTypes))
            {
                addressTypes = _context.AddressTypes.AsNoTracking().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.AddressTypes, addressTypes, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<AddressType>>(addressTypes.Where(c => !active.HasValue || c.Active == active.Value).ToList()); 
        }

        public AddressType GetAddressType(string name)
        {
            return GetAllAddressTypes(true).Where(c => String.Compare(name, c.TypeName, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }

       
       
    }
}
