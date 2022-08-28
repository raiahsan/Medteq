#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using Application.Dto.UserAccount;
using Application.General.Dto;

#endregion

namespace Application.ServiceInterfaces.IUserServices
{
    public interface IUsersService : IGenericService<User>
    {
        UserDto GetUserByID(int id);
        //Task<UserVM> UpsertUser(User user);
        Task<UserUpsertDto> Upsert(UserUpsertDto userUpserDto);
        Task<UserDto> DeleteUser(int id);
        Task<UserDto> Authenticate(string email, string password);
        UserDto GetByEmail(string email);
        RecordSet<GetUserDto> GetUsers(UserSearchDto userSearchDto);
    }
}