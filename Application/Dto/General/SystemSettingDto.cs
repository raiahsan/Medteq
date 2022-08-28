using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.General
{
   public class SystemSettingDto
    {
        public int ID { get; set; }
        public string SettingName { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public string SettingCategory { get; set; }
        public bool Active { get; set; }
        public string Label { get; set; }
    }
}
