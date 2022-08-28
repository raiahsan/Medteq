using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class PatientPayorEligibility : BaseModel
    {
        public PatientPayorEligibility()
        {
            PatientPayorEligibilityDetails = new HashSet<PatientPayorEligibilityDetail>();
        }

        public int EligibilityID { get; set; }
        public Guid? EligibilityGUID { get; set; }
        public int? fk_PatientID { get; set; }
        public int? Fk_PatientPayorID { get; set; }
        public string ProviderLastName { get; set; }
        public string ProviderFirstName { get; set; }
        public string ProviderNPI { get; set; }
        public string ProviderPIN { get; set; }
        public string ProviderTaxanomy { get; set; }
        public string VerificationType { get; set; }
        public string SubcriberLastName { get; set; }
        public string SubcriberFirstName { get; set; }
        public string SubcriberMemberID { get; set; }
        public string SubcriberSSN { get; set; }
        public string SubscriberGroupNumber { get; set; }
        public string DependentLastName { get; set; }
        public string DependentFirstName { get; set; }
        public string DependentRelationship { get; set; }
        public string PatientGender { get; set; }
        public string PatientDOB { get; set; }
        public string IssueDate { get; set; }
        public string DateOfServiceFrom { get; set; }
        public string DateOfServiceTo { get; set; }
        public string BatchName { get; set; }
        public string ServiceCodes { get; set; }
        public string Notes { get; set; }
        public bool Manual { get; set; }
        public string EligibilityRequestData { get; set; }
        public string EligiblityRawResponse { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual PatientPayor PatientPayor { get; set; }
        public virtual User ModifiedByUser { get; set; }
        public virtual ICollection<PatientPayorEligibilityDetail> PatientPayorEligibilityDetails { get; set; }
    }
}
