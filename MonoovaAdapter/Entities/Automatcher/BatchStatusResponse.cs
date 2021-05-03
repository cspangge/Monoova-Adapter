namespace MonoovaAdapter.Entities.Automatcher
{
    public class BatchStatusResponse : ResponseBase
    {
        public int NumberOfRecords { get; set; }
        
        public string BatchUrl { get; set; }
    }
}