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
    class ContactMethodRepository : GenericRepository<ContactMethod>, IContactMethodRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public ContactMethodRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }

        public List<ContactMethod> GetAllContactMethods(bool? active = null)
        {
            if (!_memoryCache.TryGetValue(CacheKey.ContactMethods, out List<ContactMethod> contactMethods))
            {
                contactMethods = _context.ContactMethods.AsNoTracking().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.ContactMethods, contactMethods, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<ContactMethod>>(contactMethods.Where(c => !active.HasValue || c.Active == active.Value).ToList());
        }

        public ContactMethod GetContactMethod(string name)
        {
            return GetAllContactMethods(true).Where(c => String.Compare(name, c.Name, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }
    }
}
