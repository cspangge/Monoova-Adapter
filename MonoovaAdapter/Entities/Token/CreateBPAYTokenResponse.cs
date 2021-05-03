namespace MonoovaAdapter.Entities.Token
{
    public class CreateBpayTokenResponse : ResponseBase
    {
        public string Token { get; set; }
        
        public string Hint { get; set; }
    }
}