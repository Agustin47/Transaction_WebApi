
namespace Services.RequestResponse
{

    using Services.Entity;
    using System.Collections.Generic;

    public class GetRatesResponse
    {

        public IList<RateEquivalence> Rates { get; set; }
    }
}
