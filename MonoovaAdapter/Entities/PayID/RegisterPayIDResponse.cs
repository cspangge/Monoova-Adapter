using MonoovaAdapter.Entities.PayID.Dto;

namespace MonoovaAdapter.Entities.PayID
{
    public class RegisterPayIdResponse : ResponseBase
    {
        public PayIdDetails PayIdDetails { get; set; }
    }
}