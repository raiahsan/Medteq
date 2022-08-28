using Application.Dto.PatientProvider;
using Application.RepositoryInterfaces;
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
    class PatientProviderRepository : GenericRepository<PatientProvider>, IPatientProviderRepository
    {
        public PatientProviderRepository(AppDbContext context) : base(context)
        {

        }
        public List<PatientProvider> GetPatientProvidersByPatientID(int patientID)
        {
            return _context.PatientProviders
              .Include(c => c.Provider)
              .Include(c => c.ProviderType)
              .Where(c => c.fk_PatientID == patientID && !c.Deleted).ToList();
        }
    }
}
