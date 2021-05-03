namespace MonoovaAdapter.Entities.Tools
{
    public class PingResponse : ResponseBase
    {
        public string Version { get; set; }
        
        public string Environment { get; set; }
    }
}