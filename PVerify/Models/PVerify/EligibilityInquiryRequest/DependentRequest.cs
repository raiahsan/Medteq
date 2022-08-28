using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVerify.Models.PVerify.EligibilityInquiryRequest
{
    public class DependentRequest
    {
        public DependentRequest()
        {
            Patient = new PatientRequest();
        }
        /// <summary>
        /// <para>Optional</para> 
        /// <para>Relation With Subscriber</para> 
        /// </summary>
        public string RelationWithSubscriber { get; set; }
        public PatientRequest Patient { get; set; }
    }
}
