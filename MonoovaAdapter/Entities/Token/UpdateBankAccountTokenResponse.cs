namespace MonoovaAdapter.Entities.Token
{
    public class UpdateBankAccountTokenResponse : ResponseBase
    {
        public string Token { get; set; }
        
        public string Hint { get; set; }
    }
}