using Application.Configurations;
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
    class ContactTypeRepository : GenericRepository<ContactType>, IContactTypeRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public ContactTypeRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }

        public List<ContactType> GetAllContactTypes(bool? active = null)
        {
            if (!_memoryCache.TryGetValue(CacheKey.ContactTypes, out List<ContactType> contactTypes))
            {
                contactTypes = _context.ContactTypes.AsNoTracking().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.ContactTypes, contactTypes, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<ContactType>>(contactTypes.Where(c => !active.HasValue || c.Active == active.Value).ToList());
        }

        public ContactType GetContactType(string name)
        {
            return GetAllContactTypes(true).Where(c => String.Compare(name, c.Type, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }

        public ContactType GetContactType(int id)
        {
            return GetAllContactTypes().Where(c => c.ID == id).FirstOrDefault();
        }

    }
}
