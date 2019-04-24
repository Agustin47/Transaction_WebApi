
namespace Services
{

    using Services.RequestResponse;

    public interface ITransactionService
    {

        /// <summary>
        /// Get all transactions or by skuId.
        /// </summary>
        /// <param name="rate">Rate to convert</param>
        /// <returns>Rate converted</returns>
        GetTransactionsResponse GetTransactions(GetTransactionsRequest request);


        /// <summary>
        /// Get all Rates.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetRatesResponse GetRates(GetRatesRequest request);
    }
}
