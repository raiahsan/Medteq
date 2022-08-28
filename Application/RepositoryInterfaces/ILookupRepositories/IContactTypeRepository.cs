#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.ILookupRepositories
{
    public interface IContactTypeRepository : IGenericRepository<ContactType>
    {
        ContactType GetContactType(string name);
        ContactType GetContactType(int id);
        List<ContactType> GetAllContactTypes(bool? active = null);
    }
}
