#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto.General;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.ILookupRepositories
{
    public interface IStateRepository : IGenericRepository<State>
    {
        State GetState(string name);
        List<State> GetAllStates(bool? active = null);
    }
}