using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Provider
{
    public class GetProviderDto
    {
        public int ID { get; set; }
        public int ParentProviderID { get; set; }
        public string Title { get; set; }
        public string Suffix { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string DoctorGroup { get; set; }
        public string Upin { get; set; }
        public string MedicalID { get; set; }
        public string Deanumber { get; set; }
        public DateTime? DeaexpiryDate { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public string StateMedicaidID { get; set; }
        public string NPINumber { get; set; }
        public string CommercialNumber { get; set; }
        public string TaxonomyCode { get; set; }
        public string Specialty { get; set; }
        public string IMSRxerID { get; set; }
        public string Location { get; set; }
        public int? MarketDecile { get; set; }
        public string DegreeDescription { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
    }
}
