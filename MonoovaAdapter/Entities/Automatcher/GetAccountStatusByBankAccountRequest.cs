using Newtonsoft.Json;

namespace MonoovaAdapter.Entities.Automatcher
{
    public class GetAccountStatusByBankAccountRequest
    {
        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }
    }
}