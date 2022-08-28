#region Imports
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using Application.General.Dto;
using Application.Dto.UserAccount;
using Microsoft.Data.SqlClient;
using Application.Helper;
using System.Text.Json;
using Application.RepositoryInterfaces;
using Infrastructure.Persistence;
using Application.RepositoryInterfaces.IUserRepositories;

#endregion

namespace Infrastructure.Repositories.UserRepositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(AppDbContext context) : base(context)
        {
        }

        public Task<User> GetUserByEmail(string email)
        {
            try
            {
                return _context.Users.Where(u => u.Email == email && !u.IsDeleted).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _context.Users.Include(c => c.UserToRoles).ThenInclude(c => c.Role)
                .Where(c => c.Email == email && c.Active && !c.IsDeleted)
                .Select(c => new User
                {
                    ID = c.ID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CreatedBy = c.CreatedBy,
                    CreatedDate = c.CreatedDate,
                    ModifiedBy = c.ModifiedBy,
                    ModifiedDate = c.ModifiedDate,
                    fk_BranchID = c.fk_BranchID,
                    Email = c.Email,
                    Active = c.Active,
                    IsDeleted = c.IsDeleted,
                    Password = c.Password,
                    UserToRoles = c.UserToRoles.Select(userRole =>
                        new UserToRole
                        {
                            fk_RoleID = userRole.fk_RoleID,
                            fk_UserID = userRole.fk_UserID,
                            Role = userRole.Role
                        }).ToList()
                })
                .FirstOrDefaultAsync();
            return user != null && user.Password.VerifyWithBCrypt(password) ? user : null;
        }

        public RecordSet<GetUserDto> GetUsers(UserSearchDto userSearchDto)
        {
            var result = _context.ExecuteSqlStoredProcedure("sp_GetUsers", new List<SqlParameter>
            {
                new SqlParameter("@email", !String.IsNullOrWhiteSpace(userSearchDto.Email) ? userSearchDto.Email : Convert.DBNull),
                new SqlParameter("@userID", userSearchDto.UserId.HasValue ? userSearchDto.UserId.Value : Convert.DBNull),
                new SqlParameter("@pageSize", userSearchDto.PageSize),
                new SqlParameter("@pageIndex", userSearchDto.PageIndex),
                new SqlParameter("@active",userSearchDto.Active ?? Convert.DBNull),
                new SqlParameter("@sortColumn", !String.IsNullOrWhiteSpace(userSearchDto.SortColumn) ? userSearchDto.SortColumn : Convert.DBNull),
                new SqlParameter("@sortDirection", !String.IsNullOrWhiteSpace(userSearchDto.SortDirection) ? userSearchDto.SortDirection : Convert.DBNull),
            });
            var totalRecords = Convert.ToInt32(result.Tables[0].Rows[0][0]);
            var users = JSONSerializerHelper.Deserialize<List<GetUserDto>>(result.Tables[1]);
            return new RecordSet<GetUserDto>
            {
                Items = users,
                TotalRows = totalRecords,
            };
        }

        public User GetUserByID(int UserID)
        {
            return _context.Users.Include(c => c.UserToRoles).ThenInclude(c => c.Role)
                .Select(c => new User
                {
                    ID = c.ID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CreatedBy = c.CreatedBy,
                    CreatedDate = c.CreatedDate,
                    ModifiedBy = c.ModifiedBy,
                    ModifiedDate = c.ModifiedDate,
                    fk_BranchID = c.fk_BranchID,
                    Email = c.Email,
                    Active = c.Active,
                    IsDeleted = c.IsDeleted,
                    UserToRoles = c.UserToRoles.Select(userRole =>
                        new UserToRole
                        {
                            fk_RoleID = userRole.fk_RoleID,
                            fk_UserID = userRole.fk_UserID,
                            Role = userRole.Role
                        }).ToList()
                })
               .Where(c => c.ID == UserID && c.Active && !c.IsDeleted).FirstOrDefault();
        }
    }
}