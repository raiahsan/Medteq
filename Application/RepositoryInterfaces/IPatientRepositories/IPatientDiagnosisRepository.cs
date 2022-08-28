using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IPatientRepositories
{
    public interface IPatientDiagnosisRepository : IGenericRepository<PatientDiagnosis>
    {
        PatientDiagnosis GetPatientDiagnosisByID(int patientDiagnosisID);
        List<PatientDiagnosis> GetPatientDiagnosisByPatientID(int patientID);
    }
}
