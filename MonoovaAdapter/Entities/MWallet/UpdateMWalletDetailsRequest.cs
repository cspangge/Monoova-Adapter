using System.Collections.Generic;
using MonoovaAdapter.Entities.MWallet.Dto;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.MWallet
{
    public class UpdateMWalletDetailsRequest
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("pin")]
        public string Pin { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("nickName")]
        public string NickName { get; set; }
        
        [JsonProperty("phone")]
        public string Phone { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("options")]
        public List<MobileForSms> Options { get; set; }
    }
}