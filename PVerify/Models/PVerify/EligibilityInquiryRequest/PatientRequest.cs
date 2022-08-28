using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVerify.Models.PVerify.EligibilityInquiryRequest
{
    public class PatientRequest
    {
        /// <summary>
        /// <para>Conditional</para> 
        /// <para>First Name of dependent</para>
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// <para>Optional</para> 
        /// <para>Middle Name of dependent</para>
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// <para>Conditional</para> 
        /// <para>Last Name of dependent</para>
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// <para>Required for dependent inquiry. (Expected format: MM/dd/YYYY ie 01/01/2000)</para>
        /// </summary>
        public string DOB { get; set; }
        /// <summary>
        /// <para>Optional</para> 
        /// <para>Gender of dependent</para> 
        /// </summary>
        public string Gender { get; set; }
    }
}
