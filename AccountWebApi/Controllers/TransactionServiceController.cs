using AccountWebApi.Contract.Contracts;
using AccountWebApi.Entities.Model;
using AccountWebApi.Logger.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AccountWebApi.Controllers
{
    /// <summary>
    /// Defines the TransactionServiceController.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionServiceController : ControllerBase
    {
        /// <summary>
        /// Defines the _service.
        /// </summary>
        private readonly ITransactionService _service;

        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILoggerManager _logger;

        /// <summary>
        /// Initializes a new instance of the TransactionServiceController class.
        /// </summary>
        /// <param name="logger">Requires an implementation of ILoggerManager.</param>
        /// <param name="serviceContext">Requires an implementation of ITransactionService.</param>
        public TransactionServiceController(ILoggerManager logger, ITransactionService serviceContext)
        {
            _service = serviceContext;
            _logger = logger;
        }

        /// <summary>
        /// Get method to retrieve transaction for an account number.
        /// </summary>
        /// <param name="accountNumber">Requires a string argument.</param>
        /// <returns>Returns an ActionResult.</returns>
        [HttpGet("{accountNumber}")]
        [ProducesResponseType(typeof(IEnumerable<AccountTransaction>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<List<AccountTransaction>> GetTransactions(string accountNumber)
        {
            _logger.LogInfo($"Processing Get Transaction for : {accountNumber}");
            var transactions = _service.GetTransactionsByAccountNumber
                (accountNumber);
            return Ok(transactions.ToList());
        }
    }
}
