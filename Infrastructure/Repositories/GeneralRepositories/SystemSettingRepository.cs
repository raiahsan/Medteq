using Application.Configurations;
using Application.Dto.General;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IGeneralRepositories;
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

namespace Infrastructure.Repositories.GeneralRepositories
{
    class SystemSettingRepository : GenericRepository<SystemSetting>, ISystemSettingRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _cacheSettings;
        public SystemSettingRepository(AppDbContext context, IMemoryCache memoryCache, IOptions<CacheSettings> cacheSettings) : base(context)
        {
            _memoryCache = memoryCache;
            _cacheSettings = cacheSettings.Value;
        }

        public List<SystemSetting> GetSystemSettings()
        {
            if (!_memoryCache.TryGetValue(CacheKey.States, out List<SystemSetting> systemSettings))
            {
                systemSettings = _context.SystemSettings.AsNoTracking().ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(_cacheSettings.AbsoluteExpirationTimeInHours));

                _memoryCache.Set(CacheKey.SystemSetting, systemSettings, cacheEntryOptions);
            }
            return JSONSerializerHelper.Deserialize<List<SystemSetting>>(systemSettings.ToList());
        }
    
    }
}
