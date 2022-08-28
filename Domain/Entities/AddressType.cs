using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class AddressType
    {
        public AddressType()
        {
            PatientAddresses = new HashSet<PatientAddress>();
        }

        public int ID { get; set; }
        public string TypeName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PatientAddress> PatientAddresses { get; set; }
    }
}
