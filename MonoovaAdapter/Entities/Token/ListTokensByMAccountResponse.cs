using System.Collections.Generic;
using MonoovaAdapter.Entities.Token.Dto;

namespace MonoovaAdapter.Entities.Token
{
    public class ListTokensByMAccountResponse : ResponseBase
    {
        public List<TokenDetails> Tokens { get; set; }
    }
}