namespace MonoovaAdapter.Entities.Tools
{
    public class ValidateAbnResponse : ResponseBase
    {
        public string Abn { get; set; }
        
        public string LastUpdatedDate { get; set; }
        
        public bool IsAbnValid { get; set; }
        
        public bool IsCharity { get; set; }
        
        public string EntityTypeCode { get; set; }
        
        public string EntityTypeDescription { get; set; }
        
        public string OrganisationName { get; set; }
        
        public string LegalName { get; set; }
        
        public string OrganisationNameFromDate { get; set; }
        
        public string BusinessPhysicalAddressStateCode { get; set; }
        
        public string BusinessPhysicalAddressPostCode { get; set; }
        
        public string BusinessPhysicalAddressEffectiveFromDate { get; set; }
    }
}