using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class SystemSetting
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
