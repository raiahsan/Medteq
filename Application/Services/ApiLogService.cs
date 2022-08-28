using Domain;
using Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;

namespace Application.Services
{
    public class ApiLogService : IApiLogService
    {
        private readonly IMapper _mapper;
        private readonly IApiLogRepository _apiLogRepository;

        public ApiLogService(IApiLogRepository apiLogRepository, IMapper mapper)
        {
            _apiLogRepository = apiLogRepository;
            _mapper = mapper;
        }
        public async Task<ApiLog> Create(ApiLog apiLog)
        {
            try
            {
                await _apiLogRepository.Add(apiLog);
                _apiLogRepository.Complete();
                return apiLog;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
