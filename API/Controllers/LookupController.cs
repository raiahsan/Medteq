using API.Helpers;
using Application.ServiceInterfaces;
using Application.ServiceInterfaces.IGeneralServices;
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
    public class LookupController : BaseController
    {
        private readonly ILookupService _lookupService;
        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }
        [HttpGet("GetAllActiveStates")]
        public IActionResult GetAllActiveStates()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveStates();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "State not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActiveAddressType")]
        public IActionResult GetAllActiveAddressType()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveAddressesType();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Address not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActiveContactMethod")]
        public IActionResult GetAllActiveContactMethod()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllContactsMethod();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Contact not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActiveGenders")]
        public IActionResult GetAllActiveGenders()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveGenders();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Gender not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActiveLeadSources")]
        public IActionResult GetAllActiveLeadSources()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveLeadSources();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "LeadSource not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActiveMaritalStatus")]
        public IActionResult GetAllActiveMaritalStatus()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveMaritalStatus();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "MaritalStatus not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActiveRelationshipTypes")]
        public IActionResult GetAllActiveRelationshipTypes()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveRelationshipTypes();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "RealationshipType not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActiveICDCodeTypes")]
        public IActionResult GetAllActiveICDCodeTypes()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveICDCodeTypes();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "GetAllActiveICDCodeType not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActivePayorLevels")]
        public IActionResult GetAllActivePayorLevels()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActivePayorLevels();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "PayorLevel not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActiveLeadTypes")]
        public IActionResult GetAllActiveLeadTypes()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveLeadTypes();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "LeadTypes not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActiveContactTypes")]
        public IActionResult GetAllActiveContactTypes()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveContactTypes();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "ContactTypes not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }

        [HttpGet("GetAllActiveProviderTypes")]
        public IActionResult GetAllActiveProviderTypes()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveProviderTypes();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "ProviderType not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     GetAll Diagnosises
        /// </summary
        [HttpGet("GetAllActiveDiagnosises")]
        public IActionResult GetAllActiveDiagnosises()
        {
            return CreateHttpResponse(() =>
            {
                var response = _lookupService.GetAllActiveDiagnosises();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Diagnosises not found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
    }
}
