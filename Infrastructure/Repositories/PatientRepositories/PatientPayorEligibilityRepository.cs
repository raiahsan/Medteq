using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IPatientRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.PatientRepositories
{
    class PatientPayorEligibilityRepository : GenericRepository<PatientPayorEligibility>, IPatientPayorEligibilityRepository
    {
        public PatientPayorEligibilityRepository(AppDbContext context) : base(context)
        {
        }
    }
}
