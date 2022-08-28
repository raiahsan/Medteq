using Application.Dto.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.ILookupServices
{
    public interface ILookupService
    {
        List<LookupDto> GetAllActiveStates();
        List<LookupDto> GetAllActiveAddressesType();
        List<LookupDto> GetAllContactsMethod();
        List<LookupDto> GetAllActiveGenders();
        List<LookupDto> GetAllActiveLeadSources();
        List<LookupDto> GetAllActiveMaritalStatus();
        List<LookupDto> GetAllActiveRelationshipTypes();
        List<LookupDto> GetAllActiveICDCodeTypes();
        List<LookupDto> GetAllActivePayorLevels();
        List<LookupDto> GetAllActiveLeadTypes();
        List<LookupDto> GetAllActiveContactTypes();
        List<LookupDto> GetAllActiveProviderTypes();
        List<GetDiagnosisDto> GetAllActiveDiagnosises();
    }
}
