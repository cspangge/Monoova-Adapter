namespace MonoovaAdapter.Entities.Automatcher
{
    public class BatchCreateResponse : ResponseBase
    {
        public int NumberOfRecords { get; set; }
        
        public string BatchUrl { get; set; }
    }
}