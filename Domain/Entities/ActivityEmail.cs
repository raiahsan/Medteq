using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ActivityEmail
    {
        public int ID { get; set; }
        public int fk_ActivityID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Sender { get; set; }
        public string Recipients { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
