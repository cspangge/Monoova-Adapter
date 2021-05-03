using System.Collections.Generic;

namespace MonoovaAdapter.Entities.MAccount
{
    public class ListIssuerResponse : ResponseBase
    {
        public List<string> MAccounts { get; set; }
    }
}