

namespace Services.Entity
{
    using Domain.Contract;
    using Domain.Entity;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    public class Transactions
    {

        #region Prop
        private IDomainActions _domainActions { get; set; }


        public Transactions(IDomainActions domainActions)
        {
            _domainActions = domainActions;
        }

        #endregion

        public IList<TransactionEquivalence> Get()
        {

            var result = new HttpClient().GetAsync("http://quiet-stone-2094.herokuapp.com/transactions.json")
                            .Result.Content.ReadAsStringAsync().Result;

            if (result != null)
            {
                int id = 1;
                _domainActions.DeleteAll<TransactionDomain>();
                var rateEquivalences = JsonConvert.DeserializeObject<List<TransactionEquivalence>>(result);
                _domainActions.InsertList(
                        rateEquivalences.Select(x => new TransactionDomain
                        {
                            Id = id++,
                            Amount = x.Amount,
                            Currency = x.Currency,
                            Sku = x.Sku
                        }
                    ).ToList());
                _domainActions.Commit();
                return rateEquivalences;

            }

            return _domainActions.GetAll<TransactionDomain>().Select(x => new TransactionEquivalence
            {
                Amount = x.Amount,
                Currency = x.Currency,
                Sku = x.Sku
            }).ToList();


        }
    }
}
