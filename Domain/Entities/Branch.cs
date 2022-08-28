using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Branch : BaseModel
    {
        public Branch()
        {
            Leads = new HashSet<Lead>();
            Patients = new HashSet<Patient>();
        }

        public int ID { get; set; }
        public string BranchName { get; set; }
        public string BranchNumber { get; set; }
        public string TaxID { get; set; }
        public string NPI { get; set; }
        public string TaxonomyCode { get; set; }
        public string Region { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int? fk_StateID { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool Active { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual User ModifiedByUser { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
