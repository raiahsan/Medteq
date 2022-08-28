using Application.Dto.ContactType;
using Application.Dto.Patient;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.ILookupServices
{
    public interface IContactTypeService
    {
        Task<ContactType> UpsertContactType(ContactTypeDto contactTypeDto);
        List<ContactTypeDto> GetContactTypes();
        ContactTypeDto GetContactTypesByID(int id);
    }
}
