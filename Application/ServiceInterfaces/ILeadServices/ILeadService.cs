using Domain.Entities;
using Application.Dto.Lead;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.General.Dto;

namespace Application.ServiceInterfaces.ILeadServices
{
    public interface ILeadService
    {
        Task<Lead> UpsertLead(CreateLeadDto leadDto);
        GetLeadDto GetLeadByID(int id);
        RecordSet<GetLeadDto> GetLeads(LeadSearchDto leadSearch);

    }
}
