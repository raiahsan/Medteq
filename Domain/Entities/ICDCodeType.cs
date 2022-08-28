using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ICDCodeType
    {
        public ICDCodeType()
        {
            Diagnoses = new HashSet<Diagnosis>();
        }

        public int ID { get; set; }
        public string TypeName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Diagnosis> Diagnoses { get; set; }
    }
}
