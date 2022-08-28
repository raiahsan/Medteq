using Application.Dto.Branch;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.ILookupServices
{
    public interface IBranchService
    {
        Task<Branch> UpsertBranch(BranchDto branchDto);
        BranchDto GetBranchByID(int id);
        List<BranchDto> GetBranches();
    }
}
