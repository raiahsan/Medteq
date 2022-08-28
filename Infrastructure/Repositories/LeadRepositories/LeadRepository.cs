using Application.Dto.General;
using Application.Dto.Lead;
using Application.General.Dto;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.ILeadRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories.LeadRepositories
{
    class LeadRepository : GenericRepository<Lead>, ILeadRepository
    {
        public LeadRepository(AppDbContext context) : base(context)
        {

        }

        public Lead GetLeadById(int leadID)
        {
            return _context.Leads
                .Include(c => c.Branch)
                .Include(c => c.Gender)
                .Include(c => c.LeadSource)
                .Include(c => c.LeadType)
                .Include(c => c.Patient)
                .Include(c => c.BillingState)
                .Include(c => c.LeadContacts)
                .Where(c => c.ID == leadID).FirstOrDefault();
        }

        public RecordSet<GetLeadDto> GetLeads(LeadSearchDto leadSearch)
        {
            var result = _context.ExecuteSqlStoredProcedure("sp_GetLeads", new List<SqlParameter>
            {
                new SqlParameter("@firstName", !String.IsNullOrWhiteSpace(leadSearch.FirstName) ? leadSearch.FirstName : Convert.DBNull),
                new SqlParameter("@lastName", !String.IsNullOrWhiteSpace(leadSearch.LastName) ? leadSearch.LastName : Convert.DBNull),
                new SqlParameter("@email", !String.IsNullOrEmpty(leadSearch.Email)?leadSearch.Email:Convert.DBNull),
                new SqlParameter("@leadID", leadSearch.LeadID.HasValue ? leadSearch.LeadID.Value : Convert.DBNull),
                new SqlParameter("@pageSize", leadSearch.PageSize),
                new SqlParameter("@pageIndex", leadSearch.PageIndex),
                new SqlParameter("@sortColumn", !String.IsNullOrWhiteSpace(leadSearch.SortColumn) ? leadSearch.SortColumn : Convert.DBNull),
                new SqlParameter("@sortDirection", !String.IsNullOrWhiteSpace(leadSearch.SortDirection) ? leadSearch.SortDirection : Convert.DBNull),
                new SqlParameter("@dateOfBirth", leadSearch.DateOfBirth.HasValue ? leadSearch.DateOfBirth.Value.Date : Convert.DBNull)
            });
            var totalRecords = Convert.ToInt32(result.Tables[0].Rows[0][0]);
            var leads = JSONSerializerHelper.Deserialize<List<GetLeadDto>>(result.Tables[1]);
            return new RecordSet<GetLeadDto>
            {
                Items = leads,
                TotalRows = totalRecords
            };
        }
    }
}
