using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ProviderAvailability : BaseModel
    {
        public int ID { get; set; }
        public int fk_ProviderID { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public bool Deleted { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual User ModifiedByUser { get; set; }
    }
}
