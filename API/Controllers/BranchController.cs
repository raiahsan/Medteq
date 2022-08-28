using API.Helpers;
using Application.Dto.Branch;
using Application.ServiceInterfaces;
using Application.ServiceInterfaces.ILookupServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchController : BaseController
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        /// <summary>
        ///    Get a BranchByID
        /// </summary>
        [HttpGet("GetBranchByID")]
        public IActionResult GetBranchByID(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _branchService.GetBranchByID(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Branch not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get All Branches
        /// </summary>
        [HttpGet("GetAll")]
        public IActionResult GetAllBranches()
        {
            return CreateHttpResponse(() =>
            {
                var response = _branchService.GetBranches();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "No Branch available" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Upsert a Branch
        /// </summary>
        [HttpPost("UpsertBranch")]
        public IActionResult UpsertBranch(BranchDto branchDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _branchService.UpsertBranch(branchDto).Result;
                branchDto.ID = response?.ID ?? branchDto.ID;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Branch not found" : "Branch upserted successfully",
                    Result = branchDto,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

    }
}
