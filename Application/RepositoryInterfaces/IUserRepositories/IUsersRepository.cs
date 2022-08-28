#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto.UserAccount;
using Application.General.Dto;
using Domain.Entities;

#endregion

namespace Application.RepositoryInterfaces.IUserRepositories
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<User> Authenticate(string email, string password);
        Task<User> GetUserByEmail(string email);
        RecordSet<GetUserDto> GetUsers(UserSearchDto userSearchDto);
        User GetUserByID(int UserID);
    }
}