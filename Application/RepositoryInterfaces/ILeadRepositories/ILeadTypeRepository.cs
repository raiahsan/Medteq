#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.ILeadRepositories
{
    public interface ILeadTypeRepository : IGenericRepository<LeadType>
    {
        LeadType GetLeadType(string name);
        List<LeadType> GetAllLeadTypes(bool? active = null);
    }
}