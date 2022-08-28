using Application.Dto.UserAccount;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceInterfaces.IUserServices
{
    public interface ICurrentUserService
    {
        string Fullname { get; }
        public int UserId { get; }
        UserDto User { get; }
    }
}
