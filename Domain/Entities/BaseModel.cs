using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BaseModel
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } 
    }
}
