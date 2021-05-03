using System.Collections.Generic;

namespace MonoovaAdapter.Entities.Transaction.Dto
{
    public class FeeBreakdownDto
    {
        public FeeDetailDto DebitFee { get; set; }
        
        public List<DisbursmentFeeDto> DisbursementFees { get; set; }
    }
}