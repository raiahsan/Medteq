using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RepositoryInterfaces.IPatientRepositories
{
    public interface IPatientPayorRepository : IGenericRepository<PatientPayor>
    {
        PatientPayor GetPatientPayorWithDetails(int patientPayorID);
        List<PatientPayor> GetPatientPayorsByPatientID(int patientID);
        PatientPayor GetPatientPayorByID(int id);
    }
}
