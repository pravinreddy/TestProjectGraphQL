using Microsoft.AspNetCore.Mvc;
using TestProjectGraphQL.Services;
using Braintree;

namespace TestProjectGraphQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly ITransactionService _transactionService;


        public TransactionsController(ILogger<TransactionsController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("find/{transactionid}")]
        public async Task<ActionResult> GetTransactionDeatails(string transactionid)
        {
            var transactionDeatials = await _transactionService.GetTransactionById(transactionid);
            return transactionDeatials != null? Ok(transactionDeatials): NotFound();
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAllTransactions()
        {
            var transactionDeatials = await _transactionService.GetAllTransactions();
            return transactionDeatials != null ? Ok(transactionDeatials) : NotFound();
        }
    }
}