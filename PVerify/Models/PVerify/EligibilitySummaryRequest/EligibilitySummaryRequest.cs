using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVerify.Models.PVerify.EligibilitySummaryRequest
{
    public class EligibilitySummaryRequest
    {
        public EligibilitySummaryRequest()
        {
            Subscriber = new SubscriberRequest();
            Provider = new ProviderRequest();
            Dependent = new DependentRequest();
        }
        /// <summary>
        /// <para>Required</para> 
        /// <para>pVerify Payer Code(ie Aetna 00001)</para>
        /// </summary>
        public string PayerCode { get; set; }
        /// <summary>
        /// <para>Optional</para>
        /// <para>Payer Name</para>
        /// </summary>
        public string PayerName { get; set; }
        public ProviderRequest Provider { get; set; }
        public SubscriberRequest Subscriber { get; set; }
        public DependentRequest Dependent { get; set; }
        /// <summary>
        /// <para>Required</para>
        /// <para>True for self and False for Dependent Query</para>
        /// </summary>
        public string IsSubscriberPatient { get; set; }
        /// <summary>
        /// <para>Required</para>
        /// <para>Date of service start date (Expected format: MM/dd/YYYY ie 01/01/2000)</para>
        /// </summary>
        [JsonProperty("doS_StartDate")]
        public string DOSStartDate { get; set; }
        /// <summary>
        /// <para>Required</para>
        /// <para>Date of service end date (Expected format: MM/dd/YYYY ie 01/01/2000)</para>
        /// </summary>
        [JsonProperty("doS_EndDate")]
        public string DOSEndDate { get; set; }
        /// <summary>
        /// <para>Optional</para>
        /// <para>Please consult Practice Type Code table - sets which practice type to use, i.e. 12 for physical therapy, which will return an object with PT benefits in the results. If you do not select a practice type, the default for your account will be used. Contact pVerify for more info.</para>
        /// </summary>
        public string PracticeTypeCode { get; set; }
        /// <summary>
        /// <para>Optional</para>
        /// <para>Indicates whether to return the full text of the eligibility response</para>
        /// </summary>
        public bool IncludeTextResponse { get; set; }
        /// <summary>
        /// <para>Optional</para>
        /// <para>Patient MRN or account Number</para>
        /// </summary>
        public string ReferenceId { get; set; }
        /// <summary>
        /// <para>Required</para>
        /// <para>Location is the practice location. Note by setting this, you will lock the patient to one location, so that users that login in via our portal who are not authorized to see that location will not see the patient.</para>
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// <para>Optional</para>
        /// <para>Field from customer with their InternalId</para>
        /// </summary>
        public string InternalId { get; set; }
        /// <summary>
        /// <para>Optional</para>
        /// <para>Field from customer with their CustomerId</para>
        /// </summary>
        public string CustomerId { get; set; }

    }
}
