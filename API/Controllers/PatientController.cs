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
using Domain.Entities;
using Application.Dto.PatientProvider;
using Application.Dto.Appointment;
using Application.ServiceInterfaces.IPatientServices;
using Application.ServiceInterfaces.IProviderServices;

#endregion

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientController : BaseController
    {
        private readonly IPatientService _patientService;
        private readonly IPatientPayorService _patientPayorService;
        private readonly IAppointmentService _appointmentService;
        public PatientController(IPatientService patientService, IPatientPayorService patientPayorService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _patientPayorService = patientPayorService;
            _appointmentService = appointmentService;
        }
        /// <summary>
        ///     Upsert a patient
        /// </summary>
        [HttpPost]
        public IActionResult UpsertPatient(CreatePatientDto patientDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.UpsertPatient(patientDto).Result;
                patientDto.ID = response.ID;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Patient not found" : "Patient Upserted successfully",
                    Result = patientDto,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Upsert a patientDiagnosis
        /// </summary>
        [HttpPost("UpsertPatientDiagnosis")]
        public IActionResult UpsertPatientDiagnosis(UpsertPatientDiagnosisDto patientDiagnosisDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.UpsertPatientDiagnosis(patientDiagnosisDto);
                patientDiagnosisDto.ID = response.ID;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "PatientDiagnosis not found" : "PatientDiagnosis Upserted successfully",
                    Result = patientDiagnosisDto,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Patient By ID
        /// </summary>
        [HttpGet("GetPatientByID")]
        public IActionResult GetPatientByID(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.GetPatientByID(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Patient not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Patients
        /// </summary>
        [HttpGet("GetPatients")]
        public IActionResult GetPatients([FromQuery] PatientSearchDto patientSearch)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.GetPatients(patientSearch);
                var paginationSet = new PaginationSet<Patient>
                {
                    Items = response.Items,
                    PageIndex = patientSearch.PageIndex,
                    PageSize = patientSearch.PageSize,
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
        /// <summary>
        ///    Get Patient Addresses By Patient ID
        /// </summary>
        [HttpGet("GetPatientAddressesByPatientID")]
        public IActionResult GetPatientAddressesByPatientID(int patientID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.GetPatientAddressesByPatientID(patientID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Patient Address not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Patient Contacts By Patient ID
        /// </summary>
        [HttpGet("GetPatientContactsByPatientID")]
        public IActionResult GetPatientContactsByPatientID(int patientID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.GetPatientContactByPatientID(patientID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Patient Address not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Upsert Patient Providers
        /// </summary>
        [HttpPost("UpsertPatientProviders")]
        public IActionResult UpsertPatientProvider(UpsertPatientProviderDto upsertProviderDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.UpsertPatientProviders(upsertProviderDto);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "PatientProvider not found" : "PatientProvider Upserted successfully",
                    Result = upsertProviderDto,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get PatientProviders By Patient ID
        /// </summary>
        [HttpGet("GetPatientProvidersByPatientID")]
        public IActionResult GetPatientProvidersByPatientID(int patientID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.GetPatientProvidersByPatientID(patientID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "PatientProviders not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get PatientDiagnosis By ID
        /// </summary>
        [HttpGet("GetPatientDiagnosis")]
        public IActionResult GetPatientDiagnosis(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.GetPatientDiagnosisByID(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "PatientDiagnosis not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get PatientDiagnosis By PatientID
        /// </summary>
        [HttpGet("GetPatientDiagnosisByPatientID")]
        public IActionResult GetPatientDiagnosisByPatientID(int patientID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.GetPatientDiagnosisByPatientID(patientID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "PatientDiagnosis not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Delete a PatientProvider 
        /// </summary>
        [HttpDelete("DeletePatientProvider")]
        public async Task<IActionResult> DeletePatientProvider(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.DeletePatientProvider(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "" : "PatientProvider removed successfully",
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Delete a PatientDiagnosis 
        /// </summary>
        [HttpDelete("DeletePatientDiagnosis")]
        public async Task<IActionResult> DeletePatientDiagnosis(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _patientService.DeletePatientDiagnosis(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "" : "PatientDiagnosis removed successfully",
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
    }
}
