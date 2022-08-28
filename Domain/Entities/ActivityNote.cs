using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ActivityNote
    {
        public int ID { get; set; }
        public int fk_ActivityID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
