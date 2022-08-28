using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.UserAccount
{
    public class StatusDto
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public dynamic Object { get; set; }
        public Exception ErrorMessage { get; set; }
    }
}
