using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IPatientRepositories
{
    public interface IPatientContactRepository : IGenericRepository<PatientContact>
    {
        List<PatientContact> GetContactsByPatientID(int patientID);
    }
}
