using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;
using Services.RequestResponse;

namespace vueling_otd_t23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {

        #region Prop

        public IRateService _rateService { get; set; }


        public RateController( IRateService rateService)
        {
            _rateService = rateService;
        }


        #endregion

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return JsonConvert.SerializeObject(_rateService.GetRates(new GetRatesRequest { }).Rates);
        }
    }
}
