using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ActivityType
    {
        public ActivityType()
        {
            Activities = new HashSet<Activity>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
