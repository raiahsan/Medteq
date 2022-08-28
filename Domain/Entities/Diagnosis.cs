using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class Diagnosis
    {
        public Diagnosis()
        {
            PatientDiagnoses = new HashSet<PatientDiagnosis>();
        }

        public int ID { get; set; }
        public string Icdcode { get; set; }
        public int fk_ICDCodeTypeID { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public virtual ICDCodeType ICDCodeType { get; set; }
        public virtual ICollection<PatientDiagnosis> PatientDiagnoses { get; set; }
    }
}
