using Application.Dto.General;
using Application.Dto.Lead;
using Application.General.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RepositoryInterfaces.ILeadRepositories
{
    public interface ILeadRepository : IGenericRepository<Lead>
    {
        Lead GetLeadById(int leadID);
        RecordSet<GetLeadDto> GetLeads(LeadSearchDto leadSearch);
    }
}
