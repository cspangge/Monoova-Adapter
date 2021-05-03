namespace MonoovaAdapter.Entities.Token
{
    public class CreateBankAccountTokenResponse : ResponseBase
    {
        public string Token { get; set; }
        
        public string Hint { get; set; }
    }
}