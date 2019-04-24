
namespace Services
{
    using Domain.Contract;
    using Services.Entity;
    using Services.InternalServices;
    using Services.RequestResponse;
    using System;
    using System.Linq;

    public class TransactionService : ITransactionService
    {

        #region Prop

        public TransactionInternalService _transactionInternalService { get; set; }
        private IDomainActions _domainActions { get; set; }


        public TransactionService(IDomainActions domainActions)
        {
            _transactionInternalService = new TransactionInternalService(domainActions);
            _domainActions = domainActions;
        }

        #endregion

        public GetRatesResponse GetRates(GetRatesRequest request)
        {
            return new GetRatesResponse
            {
                Rates = new RatesScales(_domainActions).Get()
            };
        }


        public GetTransactionsResponse GetTransactions(GetTransactionsRequest request)
        {

            var response = new GetTransactionsResponse
            {
                Transactions = new Transactions(_domainActions).Get()
            };

            if (string.IsNullOrEmpty(request.SkuId)) return response;

            var finalCurrency = "EUR";

            response.Transactions = response.Transactions.Where(x => x.Sku == request.SkuId).
                Select(x => new TransactionEquivalence
                {
                    Sku = x.Sku,
                    Currency = finalCurrency,
                    Amount  = decimal.Round( x.Amount * _transactionInternalService.ConvertFrom(
                        new RateEquivalence
                        {
                            From = x.Currency,
                            To = finalCurrency
                        }).Rate, 2, MidpointRounding.AwayFromZero)
                }).ToList();

            response.TotalAmount = response.Transactions.GroupBy(x => x.Sku).Select(x => x.Sum(y => y.Amount)).FirstOrDefault();


            return response;

        }
    }
}
