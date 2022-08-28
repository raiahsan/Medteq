using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Provider
{
    public class ProviderUnavailabilityDto
    {
        public int ID { get; set; }
        public int fk_ProviderID { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public bool Deleted { get; set; }
    }
}
