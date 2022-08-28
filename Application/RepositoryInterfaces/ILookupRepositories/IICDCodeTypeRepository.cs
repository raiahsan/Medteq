#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto.General;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.ILookupRepositories
{
    public interface IICDCodeTypeRepository : IGenericRepository<ICDCodeType>
    {
        ICDCodeType GetICDCodeType(string name);
        List<ICDCodeType> GetAllICDCodeTypes(bool? active = null);

    }
}