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
    public class ExceptionLogService : IExceptionLogService
    {
        private readonly IMapper _mapper;
        private readonly IExceptionLogRepository _exceptionLogRepository;

        public ExceptionLogService(IExceptionLogRepository exceptionLogRepository, IMapper mapper)
        {
            _exceptionLogRepository = exceptionLogRepository;
            _mapper = mapper;
        }
        public async Task<ExceptionLog> Create(int entityID, string entityName, string method, string json, string RequestUrl, string requestBodyJson, string exception)
        {
            try
            {
                var exceptionLog = new ExceptionLog
                {
                    EntityID = entityID,
                    EntityName = entityName,
                    JSON = json,
                    RequestUrl = RequestUrl,
                    RequestJSON = requestBodyJson,
                    Method = method,
                    Exception = exception
                };
                await _exceptionLogRepository.Add(exceptionLog);
                _exceptionLogRepository.Complete();
                return exceptionLog;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
