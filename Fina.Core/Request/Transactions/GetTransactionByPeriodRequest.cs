using Fina.Core.Request;

namespace Fina.Core.Request.Transactions
{

    public class GetTransactionByPeriodRequest : PagedRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
    }
}

