using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.PVerify
{
    public class PayerDto
    {
        public string PayerCode { get; set; }
        public string PayerName { get; set; }
        public bool IsActive { get; set; }
        public bool IsSupportingEligibility { get; set; }
        public bool IsSupportingClaims { get; set; }
        public bool IsEDIPayer { get; set; }
    }
}
