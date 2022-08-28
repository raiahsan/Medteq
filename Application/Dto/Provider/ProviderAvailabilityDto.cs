using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Provider
{
    public class ProviderAvailabilityDto
    {
        public int ID { get; set; }
        public int fk_ProviderID { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public bool Deleted { get; set; }
    }
}
