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
    public class PatientDiagnosisRepository : GenericRepository<PatientDiagnosis>, IPatientDiagnosisRepository
    {
        public PatientDiagnosisRepository(AppDbContext context) : base(context)
        {

        }

        public PatientDiagnosis GetPatientDiagnosisByID(int patientDiagnosisID)
        {
            return _context.PatientDiagnoses.Where(c => c.ID == patientDiagnosisID && !c.IsDeleted).FirstOrDefault();
        }

        List<PatientDiagnosis> IPatientDiagnosisRepository.GetPatientDiagnosisByPatientID(int patientID)
        {
            return _context.PatientDiagnoses
                .Include(c=>c.Diagnosis)
                .Include(c=>c.Patient)
                .Where(c => c.fk_PatientID == patientID && !c.IsDeleted).ToList();
        }
    }
}
