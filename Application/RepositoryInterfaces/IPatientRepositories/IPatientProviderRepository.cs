using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IPatientRepositories
{
    public interface IPatientProviderRepository : IGenericRepository<PatientProvider>
    {
        List<PatientProvider> GetPatientProvidersByPatientID(int patientID);
    }
}
