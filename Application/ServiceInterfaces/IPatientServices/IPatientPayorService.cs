using Domain.Entities;
using Application.Dto.Lead;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.PatientPayor;

namespace Application.ServiceInterfaces.IPatientServices
{
    public interface IPatientPayorService
    {
        List<GetPatientPayorDto> GetPatientPayorsByPatientID(int patientID);
        GetPatientPayorDto GetPatientPayorByID(int id);
        Task<PatientPayor> UpsertPatientPayor(CreatePatientPayorDto patientPayorDto);
        Task<PatientPayorEligibility> CheckPatientPayorEligibilityAsync(CheckPatientPayorEligibilityDto eligibilityDto);
        GetPatientPayorDto DeletePatientPayor(int id);
    }
}
