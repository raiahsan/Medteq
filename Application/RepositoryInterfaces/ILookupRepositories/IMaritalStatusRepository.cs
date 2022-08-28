#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto.General;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.ILookupRepositories
{
    public interface IMaritalStatusRepository : IGenericRepository<MaritalStatus>
    {
        MaritalStatus GetMaritalStatus(string name);
        List<MaritalStatus> GetAllMaritalStatuses(bool? active = null);
      
    }
}