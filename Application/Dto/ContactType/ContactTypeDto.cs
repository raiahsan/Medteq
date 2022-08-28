using Application.RepositoryInterfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.ContactType
{
    public class ContactTypeDto
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
    }

}

