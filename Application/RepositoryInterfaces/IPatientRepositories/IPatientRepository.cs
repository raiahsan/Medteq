using Application.Dto.Patient;
using Application.General.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RepositoryInterfaces.IPatientRepositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Patient GetPatientWithDetails(int patientID);
        RecordSet<Patient> GetPatients(PatientSearchDto patientSearch);
    }
}
