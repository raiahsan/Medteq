using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IPatientRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories.PatientRepositories
{
    class PatientPayorRepository : GenericRepository<PatientPayor>, IPatientPayorRepository
    {
        public PatientPayorRepository(AppDbContext context) : base(context)
        {
        }

        public PatientPayor GetPatientPayorByID(int id)
        {
            return _context.PatientPayors
               .Include(c => c.Payor)
               .Include(c => c.PayorLevel)
               .Include(c => c.PolicyHolderGender)
               .Include(c => c.Patient)
               .Where(c => c.ID == id && c.Active && !c.Deleted).FirstOrDefault();
        }

        public List<PatientPayor> GetPatientPayorsByPatientID(int patientID)
        {
            return _context.PatientPayors
                .Include(c => c.Payor)
                .Include(c => c.PayorLevel)
                .Include(c => c.PolicyHolderGender)
                .Include(c => c.Patient)
                .Where(c => c.fk_PatientID == patientID && c.Active && !c.Deleted).ToList();
        }

        public PatientPayor GetPatientPayorWithDetails(int patientPayorID)
        {
            return _context.PatientPayors
                .Include(c => c.Payor)
                .Include(c => c.PayorLevel)
                .Include(c => c.PolicyHolderGender)
                .Include(c => c.Patient)
                .Where(c => c.ID == patientPayorID && c.Active && !c.Deleted).FirstOrDefault();
        }
    }
}
