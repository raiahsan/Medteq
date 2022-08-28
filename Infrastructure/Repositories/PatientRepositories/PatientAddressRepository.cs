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
    class PatientAddressRepository : GenericRepository<PatientAddress>, IPatientAddressRepository
    {
        public PatientAddressRepository(AppDbContext context) : base(context)
        {

        }

        public List<PatientAddress> GetAddressesByPatientID(int patientID)
        {
            return _context.PatientAddresses
                .Include(c => c.AddressType)
                .Include(c => c.State)
                .Where(p => p.fk_PatientID == patientID).ToList();
        }
    }
}
