using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.UserAccount
{
    public class AccountSuccessDto
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public Exception ErrorMessage { get; set; }
    }
}
