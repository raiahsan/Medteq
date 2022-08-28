using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVerify.Models.PVerify.EligibilityInquiryRequest
{
    public class ProviderRequest
    {
        /// <summary>
        /// <para>Optional</para> 
        /// <para>Provider First Name</para>
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// <para>Optional</para> 
        /// <para>Provider Middle Name</para>
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// <para>Required</para> 
        /// <para>Provider Last Name</para>
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// <para>Required</para> 
        /// <para>10-Digit NPI Value</para>
        /// </summary>
        public string NPI { get; set; }
        /// <summary>
        /// <para>Required for payer Medi-Cal</para> 
        /// </summary>
        public string PIN { get; set; }
        /// <summary>
        /// <para>Optional</para> 
        /// <para>Taxonomy</para>
        /// </summary>
        public string Taxonomy { get; set; }
    }
}
