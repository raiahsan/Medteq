using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IProviderRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ProviderRepositories
{
    public class ProviderUnavailabilityRepository : GenericRepository<ProviderUnavailability> , IProviderUnavailabilityRepository
    {
        public ProviderUnavailabilityRepository(AppDbContext context) : base(context)
        {

        }
    }
}
