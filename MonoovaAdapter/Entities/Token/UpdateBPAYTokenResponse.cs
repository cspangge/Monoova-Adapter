namespace MonoovaAdapter.Entities.Token
{
    public class UpdateBpayTokenResponse : ResponseBase
    {
        public string Token { get; set; }
        
        public string Hint { get; set; }
    }
}