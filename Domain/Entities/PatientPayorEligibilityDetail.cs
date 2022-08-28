﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class PatientPayorEligibilityDetail
    {
        public int EligibilityDetailID { get; set; }
        public int fk_PatientPayorEligiblityID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int? fk_StateID { get; set; }
        public string ZipCode { get; set; }
        public DateTime? Dob { get; set; }
        public string Relationship { get; set; }
        public string Gender { get; set; }
        public string MemberID { get; set; }
        public string EligibilityBegin { get; set; }
        public string PlanText { get; set; }
        public string PlanType { get; set; }
        public string PlanBegin { get; set; }
        public string PlanNumber { get; set; }
        public string GroupNumber { get; set; }
        public string OtherInfo { get; set; }
        public bool Active { get; set; }
        public string ReportText { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RawJsonData { get; set; }

        public virtual PatientPayorEligibility PatientPayorEligiblity { get; set; }
        public virtual State State { get; set; }
    }
}
