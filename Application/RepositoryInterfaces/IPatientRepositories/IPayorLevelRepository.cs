#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto.General;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.IPatientRepositories
{
    public interface IPayorLevelRepository : IGenericRepository<PayorLevel>
    {
        PayorLevel GetPayorLevel(string name);
        List<PayorLevel> GetAllPayorLevels(bool? active = null);

    }
}