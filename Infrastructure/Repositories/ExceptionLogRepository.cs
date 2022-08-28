using Application.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    class ExceptionLogRepository : GenericRepository<ExceptionLog>, IExceptionLogRepository
    {
        public ExceptionLogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
