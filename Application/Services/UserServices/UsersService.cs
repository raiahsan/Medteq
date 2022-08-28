#region Imports

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using AutoMapper;
using Application.Dto.UserAccount;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using Application.Helper;
using System;
using Application.General.Dto;
using Domain.Exceptions;
using Application.ServiceInterfaces.IUserServices;
using Application.RepositoryInterfaces.IUserRepositories;
#endregion

namespace Application.Services.UserServices
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public UserDto GetUserByID(int id)
        {
            var user = _usersRepository.GetUserByID(id);
            return user != null ? _mapper.Map<UserDto>(user) : null;
        }
        public UserDto GetByEmail(string email)
        {
            var user = _usersRepository.GetUserByEmail(email).Result;
            return user != null ? _mapper.Map<UserDto>(user) : null;
        }
        public async Task<UserDto> DeleteUser(int id)
        {
            try
            {
                User userDeleted = _usersRepository.GetFirst(c => c.ID == id, c => !c.Active && !c.IsDeleted);
                if (userDeleted != null)
                {
                    userDeleted.IsDeleted = true;
                    _usersRepository.Complete();
                }
                else
                {
                    throw new BadRequestException($"User '{id}' not found");
                }
                return _mapper.Map<UserDto>(userDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserDto> Authenticate(string email, string password)
        {
            var user = await _usersRepository.Authenticate(email, password);
            UserDto statusVm = _mapper.Map<UserDto>(user);
            return statusVm;
        }

        public async Task<UserUpsertDto> Upsert(UserUpsertDto userUpsertDto)
        {
            try
            {

                User user = null;
                if (userUpsertDto.ID == 0)
                {
                    var userToAdd = new User()
                    {
                        FirstName = userUpsertDto.FirstName,
                        LastName = userUpsertDto.LastName,
                        Password = userUpsertDto.Password,
                        Email = userUpsertDto.Email,
                        Active = true,
                        UserToRoles = new List<UserToRole>(){
                        new UserToRole
                        {
                             fk_RoleID = userUpsertDto.RoleID
                        }
                    }
                    };
                    if (userToAdd.Password.IsNotNullOrWhiteSpace())
                    {
                        userToAdd.Password = userToAdd.Password.WithBCrypt();
                    }
                    await _usersRepository.Add(userToAdd);
                    user = userToAdd;
                }
                else
                {
                    var userToUpdate = _usersRepository.GetFirst(c => c.ID == userUpsertDto.ID, c => c.UserToRoles);
                    if (userToUpdate != null)
                    {
                        userToUpdate.FirstName = userUpsertDto.FirstName;
                        userToUpdate.LastName = userUpsertDto.LastName;
                        userToUpdate.Password = userUpsertDto.Password;
                        if (userToUpdate.UserToRoles.Count > 0)
                        {
                            userToUpdate.UserToRoles.First().fk_RoleID = userUpsertDto.RoleID;
                        }
                        else
                        {
                            userToUpdate.UserToRoles.Add(new UserToRole
                            {
                                fk_RoleID = userUpsertDto.RoleID
                            });
                        }

                        if (userToUpdate.Password.IsNotNullOrWhiteSpace())
                        {
                            userToUpdate.Password = userToUpdate.Password.WithBCrypt();
                        }

                        _usersRepository.Update(userToUpdate);
                    }
                    else
                    {
                        throw new BadRequestException($"User '{userUpsertDto.ID}' not found");
                    }
                    user = userToUpdate;
                }
                _usersRepository.Complete();
                return _mapper.Map<UserUpsertDto>(user);
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public RecordSet<GetUserDto> GetUsers(UserSearchDto userSearchDto)
        {
            try
            {
                return _usersRepository.GetUsers(userSearchDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}