using System.Collections.Generic;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount
{
    public class UpdateMAccountDetailsRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("abn")]
        public string Abn { get; set; }
        
        [JsonProperty("contactName")]
        public string ContactName { get; set; }
        
        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }
        
        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }
        
        [JsonProperty("suburb")]
        public string Suburb { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
        
        [JsonProperty("postCode")]
        public string PostCode { get; set; }
        
        [JsonProperty("bsb")]
        public string Bsb { get; set; }
        
        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }
        
        [JsonProperty("bankAccountTitle")]
        public string BankAccountTitle { get; set; }
        
        [JsonProperty("financials")]
        public string Financials { get; set; }
        
        [JsonProperty("options")]
        public List<object> Options { get; set; }
    }
}