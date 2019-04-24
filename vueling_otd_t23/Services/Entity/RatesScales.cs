

namespace Services.Entity
{
    using Domain.Contract;
    using Domain.Entity;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    public class RatesScales
    {
        #region Prop
        private IDomainActions _domainActions { get; set; }


        public RatesScales( IDomainActions domainActions)
        {
            _domainActions = domainActions;
        }
        
        #endregion

        public IList<RateEquivalence> Get()
        {

            var result = new HttpClient().GetAsync("http://quiet-stone-2094.herokuapp.com/rates.json")
                            .Result.Content.ReadAsStringAsync().Result;

            if (result != null)
            {
                int id = 1;
                _domainActions.DeleteAll<RateDomain>();
                var rateEquivalences = JsonConvert.DeserializeObject<List<RateEquivalence>>(result);
                _domainActions.InsertList(
                        rateEquivalences.Select(x => new RateDomain
                        {
                            From = x.From, To = x.To, Rate = x.Rate, Id = id++
                        }
                    ).ToList());
                _domainActions.Commit();

                return rateEquivalences;

            }

            return _domainActions.GetAll<RateDomain>().Select(x => new RateEquivalence
            {
                From = x.From,
                Rate = x.Rate,
                To = x.To
            }).ToList();
            

        } 

    }
}
