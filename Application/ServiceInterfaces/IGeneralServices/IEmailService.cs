using Application.Dto.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IGeneralServices
{
   public interface IEmailService
    {
        bool SendResetPasswordEmail(UserDto userDetail);
    }
}
