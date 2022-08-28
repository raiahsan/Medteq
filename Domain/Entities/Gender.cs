using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Gender
    {
        public Gender()
        {
            Leads = new HashSet<Lead>();
            PatientPayors = new HashSet<PatientPayor>();
            Patients = new HashSet<Patient>();
        }

        public int ID { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }
        public virtual ICollection<PatientPayor> PatientPayors { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
