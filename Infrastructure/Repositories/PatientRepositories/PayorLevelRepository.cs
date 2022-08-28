using Application.Configurations;
using Application.Dto.General;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IPatientRepositories;
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

namespace Infrastructure.Repositories.PatientRepositories
{
    class PayorLevelRepository : GenericRepository<PayorLevel>, IPayorLevelRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public PayorLevelRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }

        public List<PayorLevel> GetAllPayorLevels(bool? active = null)
        {
            if (!_memoryCache.TryGetValue(CacheKey.PayorLevels, out List<PayorLevel> payorLevels))
            {
                payorLevels = _context.PayorLevels.AsNoTracking().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.PayorLevels, payorLevels, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<PayorLevel>>(payorLevels.Where(c => !active.HasValue || c.Active == active.Value).ToList());
        }
        public PayorLevel GetPayorLevel(string name)
        {
            return GetAllPayorLevels(true).Where(c => String.Compare(name, c.Name, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
        }
    }
}
