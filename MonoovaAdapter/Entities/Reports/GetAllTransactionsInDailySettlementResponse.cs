using System.Collections.Generic;
using MonoovaAdapter.Entities.Reports.Dto;

namespace MonoovaAdapter.Entities.Reports
{
    public class GetAllTransactionsInDailySettlementResponse
    {
        public List<GenericPaymentSettlementItem> Settlements { get; set; }
    }
}