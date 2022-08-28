using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.PatientProvider
{
    public class PatientProviderDto
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int ProviderTypeID { get; set; }
        public int ProviderID { get; set; }
        public bool Deleted { get; set; }
    }
}
