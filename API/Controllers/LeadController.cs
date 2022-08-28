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
using Application.ServiceInterfaces.ILeadServices;
using Domain.Entities;

#endregion

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeadController : BaseController
    {
        private readonly ILeadService _leadService;
        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }
        /// <summary>
        ///     Upsert a lead
        /// </summary>
        
        [HttpPost("UpsertLead")]
        public IActionResult UpsertLead(CreateLeadDto leadDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _leadService.UpsertLead(leadDto).Result;
                leadDto.ID = response?.ID ?? leadDto.ID;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Lead not found" : "Lead upserted successfully",
                    Result = leadDto,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Get Lead By ID
        /// </summary>
        [HttpGet("GetLeadByID")]
        public IActionResult GetLeadByID(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _leadService.GetLeadByID(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Lead not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Leads
        /// </summary>
        [HttpGet("GetLeads")]
        public IActionResult GetLeads([FromQuery] LeadSearchDto leadSearch )
        {
            return CreateHttpResponse(() =>
            {
                var response = _leadService.GetLeads(leadSearch);
                var paginationSet = new PaginationSet<GetLeadDto>
                {
                    Items = response.Items,
                    PageIndex = leadSearch.PageIndex,
                    PageSize = leadSearch.PageSize,
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