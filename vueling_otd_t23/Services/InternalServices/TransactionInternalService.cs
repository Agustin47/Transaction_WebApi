

namespace Services.InternalServices
{
    using Domain.Contract;
    using Services.Entity;
    using System.Linq;

    public class TransactionInternalService
    {

        private IDomainActions _domainActions { get; set; }

        public TransactionInternalService(IDomainActions domainActions)
        {
            _domainActions = domainActions;
        }

        /// <summary>
        /// Rate convert.
        /// </summary>
        /// <param name="rate">Rate to convert</param>
        /// <returns>Rate converted</returns>
        public RateEquivalence ConvertFrom(RateEquivalence rate)
        {
            if (rate.From == rate.To) return new RateEquivalence { From = rate.From, To = rate.To, Rate = 1 };

            var ratesScales = new RatesScales(_domainActions).Get();

            var response = ratesScales.Where(x => x.From == rate.From && x.To == rate.To).FirstOrDefault();

            if (response != null) return response;

            var _from = ratesScales.Where(x => x.From == rate.From).ToList();

            var _to = ratesScales.Where(x => x.To == rate.To).ToList();

            response = new RateEquivalence
            {
                From = rate.From,
                To = rate.To,
                Rate = (from f in _from
                        join t in _to
                         on f.To equals t.From
                        select f.Rate * t.Rate).FirstOrDefault()
            };
            return response;
        }



    }
}
