
namespace Services.RequestResponse
{

    using Services.Entity;
    using System.Collections.Generic;

    public class GetTransactionsResponse
    {

        public IList<TransactionEquivalence> Transactions { get; set; }


        public decimal TotalAmount { get; set; }
    }
}
