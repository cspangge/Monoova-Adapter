using System.Collections.Generic;
using MonoovaAdapter.Entities.MWallet.Dto;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MWallet
{
    public class CreateMWalletRequest
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("pin")]
        public string Pin { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("nickName")]
        public string NickName { get; set; }
        
        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }
        
        [JsonProperty("phone")]
        public string Phone { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("allowDuplicates")]
        public bool AllowDuplicates { get; set; }
        
        [JsonProperty("options")]
        public List<MobileForSms> Options { get; set; }
    }
}