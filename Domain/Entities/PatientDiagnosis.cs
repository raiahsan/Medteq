using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class PatientDiagnosis : BaseModel
    {
        public int ID { get; set; }
        public int fk_PatientID { get; set; }
        public int fk_DiagnosisID { get; set; }
        public string Sequence { get; set; }
        public string ShortDescription { get; set; }
        public bool IsDeleted { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual User ModifiedByUser { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
