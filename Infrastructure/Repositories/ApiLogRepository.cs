using Application.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    class ApiLogRepository : GenericRepository<ApiLog>, IApiLogRepository
    {
        public ApiLogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
