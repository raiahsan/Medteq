using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVerify.Models.PVerify.EligibilitySummaryRequest
{
    public class SubscriberRequest
    {
        /// <summary>
        /// <para>First Name of subscriber required for self inquiry</para> 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// <para>Last Name of subscriber required for self inquiry</para> 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// <para>Required</para> 
        /// <para>MemberId required for both type inquiries(self,dependent)</para>
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// <para>Required for self-inquiry for better matching result.</para>
        /// <para>(Expected format: MM/dd/YYYY ie 01/01/2000)</para> 
        /// </summary>
        public string DOB { get; set; }
        /// <summary>
        /// <para>Optional</para> 
        /// <para>SSN of Subscriber</para>
        /// </summary>
        public string SSN { get; set; }
    }
}
