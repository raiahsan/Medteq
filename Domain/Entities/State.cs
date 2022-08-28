using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class State
    {
        public State()
        {
            Leads = new HashSet<Lead>();
            Branches = new HashSet<Branch>();
            PatientContacts = new HashSet<PatientContact>();
            PatientAddresses = new HashSet<PatientAddress>();
            PatientPayors = new HashSet<PatientPayor>();
            PatientPayorEligibilityDetails = new HashSet<PatientPayorEligibilityDetail>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<PatientContact> PatientContacts { get; set; }
        public virtual ICollection<PatientAddress> PatientAddresses { get; set; }
        public virtual ICollection<PatientPayor> PatientPayors { get; set; }
        public virtual ICollection<PatientPayorEligibilityDetail> PatientPayorEligibilityDetails { get; set; }
    }
}
