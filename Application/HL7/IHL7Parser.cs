using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HL7
{
    public interface IHL7Parser
    {
        string Encode(Patient patient);
        Patient Decode(string hl7Format);
    }
}
