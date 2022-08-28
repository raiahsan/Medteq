using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IPatientRepositories
{
    public interface IDiagnosisRepository :IGenericRepository<Diagnosis>
    {
        List<Diagnosis> GetAllDiagnosises(bool? active = null);
    }
}
