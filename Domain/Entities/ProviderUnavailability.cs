using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ProviderUnavailability : BaseModel
    {
        public int ID { get; set; }
        public int fk_ProviderID { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public bool Deleted { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
