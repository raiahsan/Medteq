using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Provider
{
    public class ProviderAvailabilityByDateTime
    {
        public int ID { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime StartTime{ get; set; }
        public DateTime EndTime{ get; set; }
        public bool Deleted{ get; set; }
    }
}
