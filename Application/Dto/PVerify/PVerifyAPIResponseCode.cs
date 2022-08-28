using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.PVerify
{
    public class PVerifyAPIResponseCode
    {
        public const int Processed = 0;
        public const int Rejected = 1;
        public const int NoFunds = 2;
        public const int Pending = 3;
        public const int New = 4;
    }
}
