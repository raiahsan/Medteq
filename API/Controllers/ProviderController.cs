using API.Helpers;
using Application.Dto.Provider;
using Application.ServiceInterfaces;
using Application.ServiceInterfaces.IProviderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProviderController : BaseController
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        #region Provider Availability Unavailability
        /// <summary>
        ///     Upsert a ProviderAvailability 
        /// </summary>
        [HttpPost("UpsertProviderAvailability")]
        public IActionResult UpsertProviderAvailability(UpsertProviderAvailabilityDto upsertProviderAvailabilityDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _providerService.UpsertProviderAvailability(upsertProviderAvailabilityDto);
                upsertProviderAvailabilityDto.ID = response?.ID ?? 0;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "ProviderAvailability not found" : "ProviderAvailability Upserted successfully",
                    Result = upsertProviderAvailabilityDto,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Upsert a ProviderUnavailability 
        /// </summary>
        [HttpPost("UpsertProviderUnavailability")]
        public IActionResult UpsertProviderUnavailability(UpsertProviderUnvailabilityDto upsertProviderUnvailabilityDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _providerService.UpsertProviderUnavailability(upsertProviderUnvailabilityDto);
                upsertProviderUnvailabilityDto.ID = response?.ID ?? 0;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "ProviderUnavailability not found" : "ProviderUnavailability Upserted successfully",
                    Result = upsertProviderUnvailabilityDto,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get All Provider 
        /// </summary>
        [HttpGet("GetAll")]
        public IActionResult GetAllProviders()
        {
            return CreateHttpResponse(() =>
            {
                var response = _providerService.GetProviders();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "No Provider available" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Get Providers
        /// </summary>
        [HttpGet("GetProviders")]
        public IActionResult GetProviders([FromQuery] ProviderSearchDto providerSearchDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _providerService.GetProviders(providerSearchDto);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Provider Not Found" : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Provider By ID
        /// </summary>
        [HttpGet("GetProviderByID")]
        public IActionResult GetProviderByID(int ID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _providerService.GetProviderByID(ID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Provider not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Provider By NPINumber
        /// </summary>
        [HttpGet("GetProviderByNPINumber")]
        public IActionResult GetProviderByNPINumber(int Npinumber)
        {
            return CreateHttpResponse(() =>
            {
                var response = _providerService.GetProviderByNPINumber(Npinumber);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Provider not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Availabilities By ProviderID
        /// </summary>
        [HttpGet("GetAvailabilitiesByProviderID")]
        public IActionResult GetAvailabilityByProviderID(int providerID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _providerService.GetAvailabilitiesByProviderID(providerID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Availability not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Unavailabilities By ProviderID
        /// </summary>
        [HttpGet("GetUnavailabilitiesByProviderID")]
        public IActionResult GetUnavailabilitiesByProviderID(int providerID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _providerService.GetUnavailabilitiesByProviderID(providerID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Unavailability not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Delete a ProviderAvailability 
        /// </summary>
        [HttpDelete("DeleteProviderAvailability")]
        public async Task<IActionResult> DeleteProviderAvailability(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _providerService.DeleteProviderAvailability(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "" : "ProviderAvailability removed successfully",
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///     Delete a ProviderUnavailability 
        /// </summary>
        [HttpDelete("DeleteProviderUnavailability")]
        public async Task<IActionResult> DeleteProviderUnavailability(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _providerService.DeleteProviderUnavailability(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "" : "ProviderUnavailability removed successfully",
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        #endregion


        /// <summary>
        ///    Update Provider List
        /// </summary>
        [HttpPost("UpdateProviderList")]
        public IActionResult UpdateProviderList()
        {
            return CreateHttpResponse(() =>
            {
                _providerService.UpdateProviderList();
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
