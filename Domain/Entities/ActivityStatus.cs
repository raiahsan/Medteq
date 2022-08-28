using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ActivityStatus
    {
        public ActivityStatus()
        {
            ActivityTasks = new HashSet<ActivityTask>();
        }

        public int ID { get; set; }
        public string Status { get; set; }
        public int Active { get; set; }

        public virtual ICollection<ActivityTask> ActivityTasks { get; set; }
    }
}
