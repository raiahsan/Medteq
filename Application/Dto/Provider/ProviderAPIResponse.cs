using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Provider
{
    public class Address
    {
        [JsonProperty("address_1")]
        public string Address1 { get; set; }
        [JsonProperty("address_2")]
        public string Address2 { get; set; }
        [JsonProperty("address_purpose")]
        public string AddressPurpose { get; set; }
        [JsonProperty("address_type")]
        public string AddressType { get; set; }
        public string City { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("country_name")]
        public string CountryName { get; set; }
        [JsonProperty("fax_number")]
        public string FaxNumber { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        public string State { get; set; }
        [JsonProperty("telephone_number")]
        public string TelephoneNumber { get; set; }
    }
    public class Basic
    {
        public string Credential { get; set; }
        [JsonProperty("enumeration_date")]
        public string EnumerationDate { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        public string Gender { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
        public string Name { get; set; }
        [JsonProperty("sole_proprietor")]
        public string SoleProprietor { get; set; }
        public string Status { get; set; }
        [JsonProperty("name_prefix")]
        public string NamePrefix { get; set; }
        [JsonProperty("name_suffix")]
        public string NameSuffix { get; set; }
    }

    public class Identifier
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        [JsonProperty("identifier")]
        public string IdentifierName { get; set; }
        public string Issuer { get; set; }
        public string State { get; set; }
    }

    public class OtherName
    {
        public string Code { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Credential { get; set; }
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
    }

    public class Taxonomy
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public string License { get; set; }
        public bool Primary { get; set; }
        public string State { get; set; }
    }

    public class PracticeLocation
    {
        [JsonProperty("address_1")]
        public string Address1 { get; set; }
        [JsonProperty("address_2")]
        public string Address2 { get; set; }
        [JsonProperty("address_type")]
        public string AddressType { get; set; }
        public string City { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("country_name")]
        public string CountryName { get; set; }
        [JsonProperty("fax_number")]
        public string FaxNumber { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        public string State { get; set; }
        [JsonProperty("telephone_number")]
        public string TelephoneNumber { get; set; }
        [JsonProperty("update_date")]
        public string UpdateDate { get; set; }
    }

    public class ProviderAPIRecords
    {
        public List<Address> Addresses { get; set; }
        public Basic Basic { get; set; }
        [JsonProperty("created_epoch")]
        public int CreatedEpoch { get; set; }
        [JsonProperty("enumeration_type")]
        public string EnumerationType { get; set; }
        public List<Identifier> Identifiers { get; set; }
        [JsonProperty("last_updated_epoch")]
        public int LastUpdatedEpoch { get; set; }
        public int Number { get; set; }
        [JsonProperty("other_names")]
        public List<OtherName> OtherNames { get; set; }
        public List<Taxonomy> Taxonomies { get; set; }
        public List<PracticeLocation> PracticeLocations { get; set; }
    }

    public class ProviderAPIResponse
    {
        [JsonProperty("result_count")]
        public int ResultCount { get; set; }
        public List<ProviderAPIRecords> Results { get; set; }
    }



}
