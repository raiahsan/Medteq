using API.Helpers;
using Application.Dto.ContactType;
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
    public class ContactTypeController : BaseController
    {
        private readonly IContactTypeService _contactTypeService;

        public ContactTypeController(IContactTypeService contactTypeService)
        {
            _contactTypeService = contactTypeService;
        }
        /// <summary>
        ///    Upsert a ContactType
        /// </summary>
        [HttpPost("UpsertContactType")]
        public IActionResult UpsertContactType(ContactTypeDto contactTypeDto)
        {
            return CreateHttpResponse(() =>
            {
                var response = _contactTypeService.UpsertContactType(contactTypeDto).Result;
                contactTypeDto.ID = response?.ID ?? contactTypeDto.ID;
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Contact not found" : "Contact upserted successfully",
                    Result = contactTypeDto,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get All ContactTypes
        /// </summary>
        [HttpGet("GetAll")]
        public IActionResult GetAllContactTypes()
        {
            return CreateHttpResponse(() =>
            {
                var response = _contactTypeService.GetContactTypes();
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Contact not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
        /// <summary>
        ///    Get a ContactTypeByID
        /// </summary>
        [HttpGet("GetContactTypeByID")]
        public IActionResult GetContactTypeByID(int id)
        {
            return CreateHttpResponse(() =>
            {
                var response = _contactTypeService.GetContactTypesByID(id);
                return new OkObjectResult(new SuccessResponseVM
                {
                    Message = response == null ? "Contact not found " : "",
                    Result = response,
                    StatusCode = HttpStatusCode.OK,
                    Success = response != null
                });
            });
        }
    }
}
