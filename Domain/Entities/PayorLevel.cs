using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class PayorLevel
    {
        public PayorLevel()
        {
            PatientPayors = new HashSet<PatientPayor>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PatientPayor> PatientPayors { get; set; }
    }
}
