using Application.Dto.Patient;
using Application.General.Dto;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IPatientRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories.PatientRepositories
{
    class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {

        }
        public RecordSet<Patient> GetPatients(PatientSearchDto patientSearch)
        {
            var result = _context.ExecuteSqlStoredProcedure("sp_GetPatients", new List<SqlParameter>
            {
                new SqlParameter("@firstName", !String.IsNullOrWhiteSpace(patientSearch.FirstName) ? patientSearch.FirstName : Convert.DBNull),
                new SqlParameter("@lastName", !String.IsNullOrWhiteSpace(patientSearch.LastName) ? patientSearch.LastName : Convert.DBNull),
                new SqlParameter("@sortColumn", !String.IsNullOrWhiteSpace(patientSearch.SortColumn) ? patientSearch.SortColumn : Convert.DBNull),
                new SqlParameter("@sortDirection", !String.IsNullOrWhiteSpace(patientSearch.SortDirection) ? patientSearch.SortDirection : Convert.DBNull),
                new SqlParameter("@patientID", patientSearch.PatientId.HasValue ? patientSearch.PatientId.Value : Convert.DBNull),
                new SqlParameter("@pageSize", patientSearch.PageSize),
                new SqlParameter("@pageIndex", patientSearch.PageIndex),
                new SqlParameter("@dateOfBirth", patientSearch.DateOfBirth.HasValue ? patientSearch.DateOfBirth.Value.Date : Convert.DBNull)
            });
            var totalRecords = Convert.ToInt32(result.Tables[0].Rows[0][0]);
            var patients = JSONSerializerHelper.Deserialize<List<Patient>>(result.Tables[1]);
            return new RecordSet<Patient>
            {
                Items = patients,
                TotalRows = totalRecords
            };
        }
        public Patient GetPatientWithDetails(int patientID)
        {
            return _context.Patients
                .Include(c => c.Gender)
                .Include(c => c.Branch)
                .Include(c => c.PatientContacts).ThenInclude(c => c.ContactType)
                .Include(c => c.PatientAddresses).ThenInclude(c => c.AddressType)
                .Include(c => c.PatientAddresses).ThenInclude(c => c.State)
                .Include(c => c.PatientContacts).ThenInclude(c => c.State)
                .Include(c => c.MaritalStatus)
                .Where(c => c.ID == patientID).FirstOrDefault();
        }
    }
}
