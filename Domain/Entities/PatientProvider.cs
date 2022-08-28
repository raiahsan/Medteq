using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class PatientProvider
    {
        public int ID { get; set; }
        public int fk_PatientID { get; set; }
        public int fk_ProviderTypeID { get; set; }
        public int fk_ProviderID { get; set; }
        public bool Deleted { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ProviderType ProviderType { get; set; }
    }
}
