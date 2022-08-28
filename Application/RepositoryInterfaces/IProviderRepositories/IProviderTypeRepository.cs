using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IProviderRepositories
{
    public interface IProviderTypeRepository: IGenericRepository<ProviderType>
    {
        ProviderType GetProviderType(string name);
        ProviderType GetProviderType(int ID);
        List<ProviderType> GetAllProviderTypes(bool? active = null);
    }
}
