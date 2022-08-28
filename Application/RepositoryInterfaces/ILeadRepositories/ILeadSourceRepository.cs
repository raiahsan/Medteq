#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto.General;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.ILeadRepositories
{
    public interface ILeadSourceRepository : IGenericRepository<LeadSource>
    {
        LeadSource GetLeadSource(string name);
        List<LeadSource> GetAllLeadSources(bool? active = null);
       
    }
}