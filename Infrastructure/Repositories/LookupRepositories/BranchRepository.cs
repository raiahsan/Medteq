using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.ILookupRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories.LookupRepositories
{
    class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context)
        {

        }

        public List<Branch> GetAllBranches(bool? active = null)
        {
            return _context.Branches
                .Include(c => c.State)
                .Where(c => !active.HasValue || c.Active == active.Value).ToList();

        }

        public Branch GetBranchById(int branchID)
        {
            return _context.Branches
                .Include(c => c.State)
                .Where(p => p.ID == branchID && p.Active).FirstOrDefault();

        }
    }
}
