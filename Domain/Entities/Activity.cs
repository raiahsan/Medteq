using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Activity : BaseModel
    {
        public Activity()
        {
            ActivityEmails = new HashSet<ActivityEmail>();
            ActivityMessages = new HashSet<ActivityMessage>();
            ActivityNotes = new HashSet<ActivityNote>();
            ActivityPhoneCalls = new HashSet<ActivityPhoneCall>();
            ActivityTasks = new HashSet<ActivityTask>();
        }

        public int ID { get; set; }
        public int fk_PatientID { get; set; }
        public int fk_ActivityTypeID { get; set; }
        public bool Trackable { get; set; }
        public bool Deleted { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual User ModifiedByUser { get; set; }
        public virtual ICollection<ActivityEmail> ActivityEmails { get; set; }
        public virtual ICollection<ActivityMessage> ActivityMessages { get; set; }
        public virtual ICollection<ActivityNote> ActivityNotes { get; set; }
        public virtual ICollection<ActivityPhoneCall> ActivityPhoneCalls { get; set; }
        public virtual ICollection<ActivityTask> ActivityTasks { get; set; }
    }
}
