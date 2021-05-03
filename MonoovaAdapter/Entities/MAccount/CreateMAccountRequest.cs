using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MAccount
{
    public class CreateMAccountRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("allowDuplicates")]
        public bool AllowDuplicates { get; set; }
        
        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50")]
        public string Name { get; set; }
        
        [JsonProperty("abn")]
        [Required(ErrorMessage = "Abn is required")]
        [MaxLength(15, ErrorMessage = "Max Length is 15")]
        public string Abn { get; set; }
        
        [JsonProperty("contactName")]
        [Required(ErrorMessage = "ContactName is required")]
        [MaxLength(30, ErrorMessage = "Max Length is 30")]
        public string ContactName { get; set; }
        
        [JsonProperty("contactNumber")]
        [Required(ErrorMessage = "ContactNumber is required")]
        [MaxLength(15, ErrorMessage = "Max Length is 15")]
        public string ContactNumber { get; set; }
        
        [JsonProperty("email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [JsonProperty("addressLine1")]
        [MaxLength(40, ErrorMessage = "Max Length is 40")]
        public string AddressLine1 { get; set; }
        
        [JsonProperty("addressLine2")]
        [Required(ErrorMessage = "AddressLine2 is required")]
        [MaxLength(40, ErrorMessage = "Max Length is 40")]
        public string AddressLine2 { get; set; }
        
        [JsonProperty("suburb")]
        [Required(ErrorMessage = "Suburb is required")]
        [MaxLength(30, ErrorMessage = "Max Length is 30")]
        public string Suburb { get; set; }
        
        [JsonProperty("state")]
        [Required(ErrorMessage = "State is required")]
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
        public object Financials { get; set; } = null;
        
        [JsonProperty("options")]
        public List<object> Options { get; set; }
    }
}