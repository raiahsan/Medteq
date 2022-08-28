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
using Application.Dto.Patient;
using Application.Dto.PatientPayor;
using Application.ServiceInterfaces.IPatientServices;

#endregion

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientPayorController : BaseController
    {
        private readonly IPatientPayorService _patientPayorService;
        public PatientPayorController(IPatientPayorService patientPayorService)
        {
            _patientPayorService = patientPayorService;
        }
        /// <summary>
        ///   Upsert PatientPayor
        /// </summary>
        [HttpPost]
        public IActionResult UpsertPatientPayor(CreatePatientPayorDto patientPayor)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientPayorService.UpsertPatientPayor(patientPayor).Result;
                patientPayor.ID = response.ID;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Patient Payor not found" : "Patient Payor Upserted successfully",
                    Result = patientPayor,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Check Patient Eligibility
        /// </summary>
        [HttpPost("CheckPatientEligibility")]
        public IActionResult CheckPatientEligibility(CheckPatientPayorEligibilityDto eligibilityDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientPayorService.CheckPatientPayorEligibilityAsync(eligibilityDto).Result;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Success",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get PatientPayor By ID
        /// </summary>
        [HttpGet("GetPatientPayorByID")]
        public IActionResult GetPatientPayorByID(int ID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientPayorService.GetPatientPayorByID(ID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "PatientPayor not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get PatientPayors By PatientID
        /// </summary>
        [HttpGet("GetPatientPayorsByPatientID")]
        public IActionResult GetPatientPayorsByPatientID(int patientID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientPayorService.GetPatientPayorsByPatientID(patientID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "PatientPayor not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Delete a PatientPayor 
        /// </summary>
        [HttpDelete("DeletePatientPayor")]
        public async Task<IActionResult> DeletePatientPayor(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientPayorService.DeletePatientPayor(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "" : "PatientPayor removed successfully",
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
    }
}