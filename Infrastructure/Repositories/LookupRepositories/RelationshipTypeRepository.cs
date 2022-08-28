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
    class RelationshipTypeRepository : GenericRepository<RelationshipType>, IRelationshipTypeRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public RelationshipTypeRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }
        public List<RelationshipType> GetAllRelationshipTypes(bool? active = null)
        {
            if (!_memoryCache.TryGetValue(CacheKey.RelationshipTypes, out List<RelationshipType> relationshipTypes))
            {
                relationshipTypes = _context.RelationshipTypes.AsNoTracking().Where(c => c.Active).ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.RelationshipTypes, relationshipTypes, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<RelationshipType>>(relationshipTypes.Where(c => !active.HasValue || c.Active == active.Value).ToList());
        }

        public RelationshipType GetRelationshipType(string name)
        {
            return GetAllRelationshipTypes(true).Where(c => String.Compare(name, c.Type, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }
    }
}
