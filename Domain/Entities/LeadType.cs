﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public class LeadType
    {
        public LeadType()
        {
            Leads = new HashSet<Lead>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }
    }
}
