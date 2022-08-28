using API.Helpers;
using Application.Dto.Appointment;
using Application.ServiceInterfaces.IProviderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : BaseController
    {
        private readonly IProviderService _providerService;
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IProviderService providerService, IAppointmentService appointmentService)
        {
            _providerService = providerService;
            _appointmentService = appointmentService;
        }
        /// <summary>
        ///    Upsert Appointment
        /// </summary>
        [HttpPost("UpsertAppointment")]
        public IActionResult UpsertAppointment(UpsertAppointmentDto upsertAppointmentDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _appointmentService.UpsertAppointment(upsertAppointmentDto);
                upsertAppointmentDto.ID = response?.ID ?? 0;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Something went wrong" : "Appointment upserted successfully",
                    Result = upsertAppointmentDto,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Appointment By ID
        /// </summary>
        [HttpGet("GetAppointmentByID")]
        public IActionResult GetAppointmentByID(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _appointmentService.GetAppointmentByID(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Appointment not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Appointments By ProviderID
        /// </summary>
        [HttpGet("GetAppointmentsByProviderID")]
        public IActionResult GetAppointmentByProviderID(int providerID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _appointmentService.GetAppointmentsByProviderID(providerID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Appointment not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get Appointments By PatientID
        /// </summary>
        [HttpGet("GetAppointmentByPatientID")]
        public IActionResult GetAppointmentsByPatientID(int patientID)
        {
            return CreateHttpResponse(() =>
            {
                var response = _appointmentService.GetAppointmentsByPatientID(patientID);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Appointment not found " : "",

                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Confirm Appointment
        /// </summary>
        [HttpGet("ConfirmAppointment")]
        public IActionResult ConfirmAppointmentByID(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _appointmentService.ConfirmAppointmentByID(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Appointment not found" : "Appointment confirmed successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Cancel Appointment 
        /// </summary>
        [HttpGet("CancelAppointment")]
        public IActionResult CancelAppointmentByID(int id)
        {

            return CreateHttpResponse(() =>
            {
                var response = _appointmentService.CancelAppointmentByID(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Appointment not found" : "Appointment cancelled successfully",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
    }
}