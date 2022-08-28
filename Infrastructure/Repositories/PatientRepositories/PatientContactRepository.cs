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
    class PatientContactRepository : GenericRepository<PatientContact>, IPatientContactRepository
    {
        public PatientContactRepository(AppDbContext context) : base(context)
        {

        }
        public List<PatientContact> GetContactsByPatientID(int patientID)
        {
            return _context.PatientContacts
                .Include(c => c.ContactType)
                .Include(c => c.State)
                .Where(p => p.fk_PatientID == patientID).ToList();
        }
    }
}



