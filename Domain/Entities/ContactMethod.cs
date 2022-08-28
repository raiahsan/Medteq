using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ContactMethod
    {
        public ContactMethod()
        {
            LeadContacts = new HashSet<LeadContact>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<LeadContact> LeadContacts { get; set; }
    }
}
