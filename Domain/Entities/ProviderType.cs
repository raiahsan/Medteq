using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ProviderType
    {
        public ProviderType()
        {
            PatientProviders = new HashSet<PatientProvider>();
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PatientProvider> PatientProviders { get; set; }
    }
}
