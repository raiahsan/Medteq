using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.UserAccount
{
    public class UserWithTokenDto
    {
        public string accessToken { get; set; }
        public UserDto User { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime RequestedServerUtcNow { get; set; }
    }
}
