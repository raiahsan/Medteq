using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ActivityPhoneCall
    {
        public int ID { get; set; }
        public int fk_ActivityID { get; set; }
        public int fk_DirectionID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool LeftVoiceMail { get; set; }
        public TimeSpan Duration { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ActivityDirection Direction { get; set; }
    }
}
