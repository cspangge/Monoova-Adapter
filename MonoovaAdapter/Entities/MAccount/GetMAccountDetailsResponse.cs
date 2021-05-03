using MonoovaAdapter.Entities.MAccount.Dto;

namespace MonoovaAdapter.Entities.MAccount
{
    public class GetMAccountDetailsResponse : ResponseBase
    {
        public MAccountDetails Details { get; set; }
    }
}