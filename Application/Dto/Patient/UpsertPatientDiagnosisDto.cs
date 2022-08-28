using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Patient
{
    public class UpsertPatientDiagnosisDto
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int DiagnosisID { get; set; }
        public string Sequence { get; set; }
        public string ShortDescription { get; set; }
    }
}
