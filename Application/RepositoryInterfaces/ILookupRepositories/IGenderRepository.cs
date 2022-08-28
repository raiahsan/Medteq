#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto.General;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.ILookupRepositories
{
    public interface IGenderRepository : IGenericRepository<Gender>
    {
        Gender GetGender(string name);
        List<Gender> GetAllGenders(bool? active = null);
       
    }
}