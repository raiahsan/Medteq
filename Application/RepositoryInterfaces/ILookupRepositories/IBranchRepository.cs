using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RepositoryInterfaces.ILookupRepositories
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Branch GetBranchById(int branchID);
        List<Branch> GetAllBranches(bool? active = null);
    }
}
