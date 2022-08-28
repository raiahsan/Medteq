using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Patient
{
    public class GetPatientDto
    {
        public int ID { get; set; }
        public string Branch { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Suffix { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOD { get; set; }
        public DateTime? DateOfAdmission { get; set; }
        public DateTime? DateOfDischarge { get; set; }
        public DateTime? DateOfOnset { get; set; }
        public string StateOfAutoAccident { get; set; }
        public string SSN { get; set; }
        public bool? HoldAcct { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int? DiscountPct { get; set; }
        public string AccountNumber { get; set; }
        public bool? HippasignatureOnFile { get; set; }
        public DateTime? MobileVerifiedDate { get; set; }
        public DateTime? EmailVerifiedDate { get; set; }
        public List<PatientAddressDto> Addresses { get; set; }
        public List<PatientContactDto> Contacts { get; set; }
    }
}
