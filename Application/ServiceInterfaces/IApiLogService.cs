using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces
{
    public interface IApiLogService
    {
        Task<ApiLog> Create(ApiLog apiLogVM);
    }
}
