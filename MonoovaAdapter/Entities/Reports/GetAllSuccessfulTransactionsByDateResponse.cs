using System.Collections.Generic;
using MonoovaAdapter.Entities.Reports.Dto;

namespace MonoovaAdapter.Entities.Reports
{
    public class GetAllSuccessfulTransactionsByDateResponse : ResponseBase
    {
        public List<GenericPaymentStatementItem> Transactions { get; set; }
    }
}