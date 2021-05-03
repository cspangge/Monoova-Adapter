namespace MonoovaAdapter.Entities.Token
{
    public class GetTokenDetailsResponse : ResponseBase
    {
        public string Token { get; set; }
        
        public string Hint { get; set; }
        
        public string PayloadType { get; set; }
        
        public string Description { get; set; }
    }
}