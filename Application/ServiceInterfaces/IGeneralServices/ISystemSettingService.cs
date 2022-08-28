using Application.Dto.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IGeneralServices
{
   public interface ISystemSettingService
    {
        List<SystemSettingDto> GetSystemSettings();
    }
}
