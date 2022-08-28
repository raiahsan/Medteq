using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ActivityTask
    {
        public int ID { get; set; }
        public int fk_ActivityID { get; set; }
        public int fk_StatusID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Due { get; set; }
        public int AssignedTo { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ActivityStatus Status { get; set; }
    }
}
