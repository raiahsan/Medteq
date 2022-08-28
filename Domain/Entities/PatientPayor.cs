﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class PatientPayor : BaseModel
    {
        public PatientPayor()
        {
            PatientPayorEligibilities = new HashSet<PatientPayorEligibility>();
        }

        public int ID { get; set; }
        public Guid PatientPayorGUID { get; set; }
        public int fk_PatientID { get; set; }
        public int fk_PayorID { get; set; }
        public int fk_PayorLevelID { get; set; }
        public int? fk_PolicyHolderGenderID { get; set; }
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
        public int? fk_InsuredStateID { get; set; }
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
        public string RawData { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Payor Payor { get; set; }
        public virtual PayorLevel PayorLevel { get; set; }
        public virtual State InsuredState { get; set; }
        public virtual Gender PolicyHolderGender { get; set; }
        public virtual ICollection<PatientPayorEligibility> PatientPayorEligibilities { get; set; }
    }
}
