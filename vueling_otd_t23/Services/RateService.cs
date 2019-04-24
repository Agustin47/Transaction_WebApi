
namespace Services
{
    using Domain.Contract;
    using Services.Entity;
    using Services.RequestResponse;

    public class RateService : IRateService
    {

        private IDomainActions _domainActions { get; set; }

        public RateService(IDomainActions domainActions)
        {
            _domainActions = domainActions;
        }


        public GetRatesResponse GetRates(GetRatesRequest request)
        {
            return new GetRatesResponse
            {
                Rates = new RatesScales(_domainActions).Get()
            };
        }
    }
}
