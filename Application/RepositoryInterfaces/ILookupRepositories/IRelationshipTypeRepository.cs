#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto.General;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.ILookupRepositories
{
    public interface IRelationshipTypeRepository : IGenericRepository<RelationshipType>
    {
        RelationshipType GetRelationshipType(string name);
        List<RelationshipType> GetAllRelationshipTypes(bool? active=null);
       
    }
}