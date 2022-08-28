using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.ILeadRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.LeadRepositories
{
    public class LeadContactRepository :GenericRepository<LeadContact>, ILeadContactRepository
    {
        public LeadContactRepository(AppDbContext context) : base(context)
        {

        }

        
    }
}
