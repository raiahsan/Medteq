using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.General
{
    public class GetDiagnosisDto
    {
        public int ID { get; set; }
        public string Icdcode { get; set; }
        public int ICDCodeTypeID { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
