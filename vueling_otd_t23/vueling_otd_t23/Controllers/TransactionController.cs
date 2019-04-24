using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;
using Services.RequestResponse;

namespace vueling_otd_t23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        #region Prop

        public ITransactionService _transactionService{ get; set; }


        public TransactionController( ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        #endregion

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return JsonConvert.SerializeObject(
                _transactionService.GetTransactions(new GetTransactionsRequest { }).Transactions);
        }

        // GET api/values
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            return JsonConvert.SerializeObject(
                _transactionService.GetTransactions(new GetTransactionsRequest { SkuId = id }));
        }


    }
}
