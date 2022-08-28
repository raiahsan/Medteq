using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class ActivityDirection
    {
        public ActivityDirection()
        {
            ActivityMessages = new HashSet<ActivityMessage>();
            ActivityPhoneCalls = new HashSet<ActivityPhoneCall>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ActivityMessage> ActivityMessages { get; set; }
        public virtual ICollection<ActivityPhoneCall> ActivityPhoneCalls { get; set; }
    }
}
