using Domain.Entities;
using Application.Dto.Lead;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Patient;
using Application.General.Dto;
using Application.Dto.PatientProvider;

namespace Application.ServiceInterfaces.IPatientServices
{
    public interface IPatientService
    {
        Task<Patient> UpsertPatient(CreatePatientDto leadDto);
        List<PatientProvider> UpsertPatientProviders(UpsertPatientProviderDto upsertProviderDto);
        PatientDiagnosis UpsertPatientDiagnosis(UpsertPatientDiagnosisDto patientDiagnosisDto);
        GetPatientDto GetPatientByID(int id);
        PatientDiagnosisDto GetPatientDiagnosisByID(int id);
        List<PatientDiagnosisDto> GetPatientDiagnosisByPatientID(int patientID);
        List<GetPatientProviderDto> GetPatientProvidersByPatientID(int patientID);
        List<PatientAddressDto> GetPatientAddressesByPatientID(int id);
        List<PatientContactDto> GetPatientContactByPatientID(int id);
        RecordSet<Patient> GetPatients(PatientSearchDto patientSearch);
        PatientProviderDto DeletePatientProvider(int id);
        PatientDiagnosisDto DeletePatientDiagnosis(int id);    
    }

}
