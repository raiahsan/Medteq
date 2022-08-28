using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.PatientPayor
{
    public class GetPatientPayorDto
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int PayorID { get; set; }
        public string PayorCode { get; set; }
        public string PayorLevel { get; set; }
        public string Gender { get; set; }
        public int GenderID { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyHolderName { get; set; }
        public DateTime? PolicyHolderDOB { get; set; }
        public string GroupNumber { get; set; }
        public string Bin { get; set; }
        public string Pcn { get; set; }
        public string NCDPDPolicyNumber { get; set; }
        public string NCPDPGroupNumber { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredLastName { get; set; }
        public string InsuredPhone { get; set; }
        public string InsuredAddress1 { get; set; }
        public string InsuredAddress2 { get; set; }
        public string InsuredCity { get; set; }
        public string State { get; set; }
        public int StateId { get; set; }
        public string InsuredZip { get; set; }
        public DateTime? PolicyStartDate { get; set; }
        public DateTime? PolicyEndDate { get; set; }
        public decimal? PayPercent { get; set; }
        public decimal? Deductible { get; set; }
        public string GroupName { get; set; }
        public string PayorContact { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public bool? InsVerified { get; set; }
        public string InsVerifiedBy { get; set; }
        public DateTime? InsVerifiedDate { get; set; }
        public string VerificationType { get; set; }
        //public string RawData { get; set; }
    }
}
