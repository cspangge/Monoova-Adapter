namespace MonoovaAdapter.Entities.Automatcher
{
    public class ListAccountsResponse : ResponseBase
    {
        public int NumberOfRecords { get; set; }
        
        public string BatchUrl { get; set; }
    }
}