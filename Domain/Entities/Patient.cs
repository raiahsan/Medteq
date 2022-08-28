using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Patient : BaseModel
    {
        public Patient()
        {
            Activities = new HashSet<Activity>();
            Appointments = new HashSet<Appointment>();
            LinkedPatients = new HashSet<Patient>();
            Leads = new HashSet<Lead>();
            PatientAddresses = new HashSet<PatientAddress>();
            PatientContacts = new HashSet<PatientContact>();
            PatientDiagnoses = new HashSet<PatientDiagnosis>();
            PatientPayorEligibilities = new HashSet<PatientPayorEligibility>();
            PatientPayors = new HashSet<PatientPayor>();
            PatientProviders = new HashSet<PatientProvider>();
            WorkflowRecords = new HashSet<WorkflowRecord>();
        }

        public int ID { get; set; }
        public Guid PatientGUID { get; set; }
        public int? fk_BranchID { get; set; }
        public int? fk_MaritalStatusID { get; set; }
        public int? fk_GenderID { get; set; }
        public int? fk_LinkedPatientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
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

        public virtual User CreatedByUser { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Patient LinkedPatient { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual User ModifiedByUser { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Patient> LinkedPatients { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<PatientAddress> PatientAddresses { get; set; }
        public virtual ICollection<PatientContact> PatientContacts { get; set; }
        public virtual ICollection<PatientDiagnosis> PatientDiagnoses { get; set; }
        public virtual ICollection<PatientPayorEligibility> PatientPayorEligibilities { get; set; }
        public virtual ICollection<PatientPayor> PatientPayors { get; set; }
        public virtual ICollection<PatientProvider> PatientProviders { get; set; }
        public virtual ICollection<WorkflowRecord> WorkflowRecords { get; set; }
    }
}
