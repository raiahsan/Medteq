using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class RelationshipType
    {
        public RelationshipType()
        {
            PatientContacts = new HashSet<PatientContact>();
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PatientContact> PatientContacts { get; set; }
    }
}
