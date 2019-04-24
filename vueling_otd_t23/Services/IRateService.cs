
namespace Services
{

    using Services.RequestResponse;

    public interface IRateService
    {
        /// <summary>
        /// Get all Rates.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetRatesResponse GetRates(GetRatesRequest request);
    }
}
