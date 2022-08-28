using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Payor : BaseModel
    {
        public Payor()
        {
            PatientPayors = new HashSet<PatientPayor>();
        }
        public int ID { get; set; }
        public Guid PayorGUID { get; set; }
        public string PayorCode { get; set; }
        public string PayorName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string SiteUrl { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactMiddleName { get; set; }
        public string ContactLastName { get; set; }
        public byte? PayPercentage { get; set; }
        public bool? AccountOnHold { get; set; }
        public string GroupName { get; set; }
        public int? GroupNumber { get; set; }
        public string CompanyName { get; set; }
        public string PlanType { get; set; }
        public string PriceTable { get; set; }
        public string ClaimPercentage { get; set; }
        public string Submission { get; set; }
        public string TaxType { get; set; }
        public string Pcn { get; set; }
        public string Bin { get; set; }
        public bool Active { get; set; }
        public string RawData { get; set; }
        public bool IsSupportingEligibility { get; set; }
        public bool IsSupportingClaims { get; set; }
        public bool IsEDIPayer { get; set; }

        public virtual ICollection<PatientPayor> PatientPayors { get; set; }
    }
}
