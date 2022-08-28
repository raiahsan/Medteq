using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Lead : BaseModel
    {
        public Lead()
        {
            LeadContacts = new HashSet<LeadContact>();
            WorkflowRecords = new HashSet<WorkflowRecord>();
        }

        public int ID { get; set; }
        public Guid LeadGUID { get; set; }
        public int fk_LeadTypeID { get; set; }
        public int fk_LeadSourceID { get; set; }
        public int fk_BranchID { get; set; }
        public int? fk_PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public DateTime DOB { get; set; }
        public int? fk_GenderID { get; set; }
        public string Email { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingAddress3 { get; set; }
        public string BillingCity { get; set; }
        public int? fk_BillingStateID { get; set; }
        public string MobilePhone { get; set; }
        public string BillingPostalCode { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorNPI { get; set; }
        public DateTime? DateLastSeenByDoctor { get; set; }
        public int? DiagnosisCode { get; set; }
        public string Notes { get; set; }
        public string LeadRawData { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual LeadSource LeadSource { get; set; }
        public virtual LeadType LeadType { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual State BillingState { get; set; }
        public virtual ICollection<LeadContact> LeadContacts { get; set; }
        public virtual ICollection<WorkflowRecord> WorkflowRecords { get; set; }
    }
}
