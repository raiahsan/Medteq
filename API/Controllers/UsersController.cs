#region Imports

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using API.Helpers;
using Application.ServiceInterfaces;
using Application.ExternalDependencies;
using Application.Dto.UserAccount;
using Domain.Entities;
using Application.ServiceInterfaces.IUserServices;

#endregion

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class UsersController : BaseController
    {
        private readonly IUsersService _usersService;
        private readonly IAccountService _accountService;
        private readonly IEmailHandler _emailService;

        public UsersController(
            IUsersService usersService,
            IAccountService accountService,
            IEmailHandler emailService
            )
        {
            _usersService = usersService;
            _accountService = accountService;
            _emailService = emailService;

        }
        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _usersService.GetUserByID(id);
                var isSuccess = response != null;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = isSuccess ? "User got successfully" : "No User found at given id",
                    Result = isSuccess ? response : null,
                    StatusCode = HttpStatusCode.OK,
                    Success = isSuccess
                });
            });
        }
        /// <summary>
        ///     Upsert a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("UpsertUser")]
        public async Task<IActionResult> UpsertUser(UserUpsertDto user)
        {
            return CreateHttpResponse(() =>
            {
                var response = _usersService.Upsert(user).Result;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "User not found" : "User Upserted successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        // DELETE api/<Users>/5
        /// <summary>
        ///     Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _usersService.DeleteUser(id).Result;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "" : "User removed successfully",
                    //Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Get Users
        /// </summary>
        [HttpGet("GetUsers")]
        public IActionResult GetUsers([FromQuery] UserSearchDto userSearchDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _usersService.GetUsers(userSearchDto);
                var paginationSet = new PaginationSet<GetUserDto>
                {
                    Items = response.Items,
                    PageIndex = userSearchDto.PageIndex,
                    PageSize = userSearchDto.PageSize,
                    TotalRows = response.TotalRows
                };
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response.Items?.Count == 0 ? "Record Not Found" : "",
                    Result = paginationSet,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }


    }
}