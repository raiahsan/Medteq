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
using Application.Dto.Lead;
using Application.ServiceInterfaces;
using Microsoft.Extensions.Caching.Memory;
using Domain.Constants;
using Application.ExternalDependencies;
using Application.ServiceInterfaces.IProviderServices;
using Application.ServiceInterfaces.IPatientServices;

#endregion

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GeneralController : BaseController
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IProviderService _providerService;
        private readonly IPayorService _payorService;
        public GeneralController(IMemoryCache memoryCache, IProviderService providerService, IPayorService payorService)
        {
            _memoryCache = memoryCache;
            _providerService = providerService;
            _payorService = payorService;
        }
        /// <summary>
        ///     Remove Cache
        /// </summary>
        [HttpPost("RemoveCache")]
        public IActionResult RemoveCache()
        {
            return CreateHttpResponse(() =>
            {
                foreach (var item in typeof(CacheKey).GetFields())
                {
                    _memoryCache.Remove(item.GetValue(null));
                }
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = "success",
                    Result = "",
                    StatusCode = HttpStatusCode.OK,
                    Success = true
                });
            });
        }
        /// <summary>
        ///    Update Payor List
        /// </summary>
        [HttpPost("UpdatePayorList")]
        public IActionResult UpdatePayorList()
        {
            return CreateHttpResponse(() =>
            {
                _payorService.UpdatePayorList();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = "success",
                    Result = "",
                    StatusCode = HttpStatusCode.OK,
                    Success = true
                });
            });
        }
    }
}