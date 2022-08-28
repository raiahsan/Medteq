#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto.General;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.ILookupRepositories
{
    public interface IContactMethodRepository : IGenericRepository<ContactMethod>
    {
        ContactMethod GetContactMethod(string name);
        List<ContactMethod> GetAllContactMethods(bool? active = null);
    }
}