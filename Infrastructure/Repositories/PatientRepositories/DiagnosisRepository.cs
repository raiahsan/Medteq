using Application.RepositoryInterfaces.IPatientRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.PatientRepositories
{
    public class DiagnosisRepository : GenericRepository<Diagnosis>, IDiagnosisRepository
    {
        public DiagnosisRepository(AppDbContext context) : base(context)
        {

        }

        public List<Diagnosis> GetAllDiagnosises(bool? active = null)
        {
            return _context.Diagnoses
                .Include(c=>c.ICDCodeType)
                .Where(c => !active.HasValue || c.Active == active.Value).ToList();
        }
    }
}
