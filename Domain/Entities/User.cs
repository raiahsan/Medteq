using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class User : BaseModel
    {
        public User()
        {
            ActivitiesCreatedByUser = new HashSet<Activity>();
            ActivitiesModifiedByUser = new HashSet<Activity>();
            AppointmentsCreatedByUser = new HashSet<Appointment>();
            AppointmentsModifiedByUser = new HashSet<Appointment>();
            BranchesCreatedByUser = new HashSet<Branch>();
            BranchesModifiedByUser = new HashSet<Branch>();
            Files = new HashSet<File>();
            //InverseCreatedByUser = new HashSet<User>();
            //InverseModifiedByUser = new HashSet<User>();
            PatientContactsCreatedByUser = new HashSet<PatientContact>();
            PatientContactsModifiedByUser = new HashSet<PatientContact>();
            PatientsCreatedByUser = new HashSet<Patient>();
            PatientsModifiedByUser = new HashSet<Patient>();
            PatientDiagnosesCreatedByUser = new HashSet<PatientDiagnosis>();
            PatientDiagnosesModifiedByUser = new HashSet<PatientDiagnosis>();
            PatientPayorEligibilitiesCreatedByUser = new HashSet<PatientPayorEligibility>();
            PatientPayorEligibilitiesModifiedByUser = new HashSet<PatientPayorEligibility>();
            ProviderAvailbilitiesCreatedByUser = new HashSet<ProviderAvailability>();
            ProviderAvailbilitiesModifiedByUser = new HashSet<ProviderAvailability>();
            UserToRoles = new HashSet<UserToRole>();
            UserWorkflowSteps = new HashSet<UserWorkflowStep>();
            WorkflowRecordNotes = new HashSet<WorkflowRecordNote>();
            WorkflowRecordStateHistories = new HashSet<WorkflowRecordStateHistory>();
            WorkflowRecordUserLocks = new HashSet<WorkflowRecordUserLock>();
            WorkflowRecords = new HashSet<WorkflowRecord>();
            WorkflowStepHistoryEnterStepUsers = new HashSet<WorkflowStepHistory>();
            WorkflowStepHistoryExitStepUsers = new HashSet<WorkflowStepHistory>();
        }

        public int ID { get; set; }
        public int fk_BranchID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string PasswordRequestHash { get; set; }
        public DateTime? PasswordRequestDate { get; set; }
        public bool IsDeleted { get; set; }
        //public virtual User CreatedByUser { get; set; }
        //public virtual User ModifiedByUser { get; set; }
        public virtual ICollection<Activity> ActivitiesCreatedByUser { get; set; }
        public virtual ICollection<Activity> ActivitiesModifiedByUser { get; set; }
        public virtual ICollection<Appointment> AppointmentsCreatedByUser { get; set; }
        public virtual ICollection<Appointment> AppointmentsModifiedByUser { get; set; }
        public virtual ICollection<Branch> BranchesCreatedByUser { get; set; }
        public virtual ICollection<Branch> BranchesModifiedByUser { get; set; }
        public virtual ICollection<File> Files { get; set; }
        //public virtual ICollection<User> InverseCreatedByUser { get; set; }
        //public virtual ICollection<User> InverseModifiedByUser { get; set; }
        public virtual ICollection<PatientContact> PatientContactsCreatedByUser { get; set; }
        public virtual ICollection<PatientContact> PatientContactsModifiedByUser { get; set; }
        public virtual ICollection<Patient> PatientsCreatedByUser { get; set; }
        public virtual ICollection<Patient> PatientsModifiedByUser { get; set; }
        public virtual ICollection<PatientDiagnosis> PatientDiagnosesCreatedByUser { get; set; }
        public virtual ICollection<PatientDiagnosis> PatientDiagnosesModifiedByUser { get; set; }
        public virtual ICollection<PatientPayorEligibility> PatientPayorEligibilitiesCreatedByUser { get; set; }
        public virtual ICollection<PatientPayorEligibility> PatientPayorEligibilitiesModifiedByUser { get; set; }
        public virtual ICollection<ProviderAvailability> ProviderAvailbilitiesCreatedByUser { get; set; }
        public virtual ICollection<ProviderAvailability> ProviderAvailbilitiesModifiedByUser { get; set; }
        public virtual ICollection<UserToRole> UserToRoles { get; set; }
        public virtual ICollection<UserWorkflowStep> UserWorkflowSteps { get; set; }
        public virtual ICollection<WorkflowRecordNote> WorkflowRecordNotes { get; set; }
        public virtual ICollection<WorkflowRecordStateHistory> WorkflowRecordStateHistories { get; set; }
        public virtual ICollection<WorkflowRecordUserLock> WorkflowRecordUserLocks { get; set; }
        public virtual ICollection<WorkflowRecord> WorkflowRecords { get; set; }
        public virtual ICollection<WorkflowStepHistory> WorkflowStepHistoryEnterStepUsers { get; set; }
        public virtual ICollection<WorkflowStepHistory> WorkflowStepHistoryExitStepUsers { get; set; }
    }
}
