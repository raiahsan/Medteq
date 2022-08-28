#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto.General;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.ILookupRepositories
{
    public interface IAddressTypeRepository : IGenericRepository<AddressType>
    {
        AddressType GetAddressType(string name);
        List<AddressType> GetAllAddressTypes(bool? active = null);
        
    }
}