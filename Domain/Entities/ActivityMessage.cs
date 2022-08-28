using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ActivityMessage
    {
        public int ID { get; set; }
        public int fk_ActivityID { get; set; }
        public int fk_DirectionID { get; set; }
        public string Sender { get; set; }
        public string Reipient { get; set; }
        public bool Sent { get; set; }
        public string Description { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ActivityDirection Direction { get; set; }
    }
}
