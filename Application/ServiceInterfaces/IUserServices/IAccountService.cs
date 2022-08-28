using Application.Dto.UserAccount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IUserServices
{
    public interface IAccountService
    {
        Task<UserDto> AuthenticateUserAccount(string username, string password);
        StatusDto ChangePassword(ChangePasswordDto changePasswordVm);
        bool UpdateChangePasswordRequestHash(string userName, string changePasswordToken);
        string ValidateChangePasswordUrl(string changePasswordToken, int urlExpiryTime);
        StatusDto ResetPassword(ResetPasswordDto resetPasswordDto);
    }
}
