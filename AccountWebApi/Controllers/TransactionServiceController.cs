using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AccountWebApi.Model;
using AccountWebApi.Contract;
using Microsoft.Extensions.Logging;

namespace AccountWebApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionServiceController : ControllerBase
    {
        private readonly ITransactionService _service;
        private readonly ILogger<TransactionServiceController> _logger;

        /// <summary>
        /// Constructor for TransactionServiceController.
        /// </summary>
        /// <param name="serviceContext">Requires an implementation of ITransactionService.</param>
        /// <param name="logger">Requires an implementation of ILogger.</param>
        public TransactionServiceController(ILogger<TransactionServiceController> logger, ITransactionService serviceContext)
        {
            _service = serviceContext;
            _logger = logger;
        }

        /// <summary>
        /// Get method to retreive transaction for an account number.
        /// </summary>
        /// <param name="accountNumber">Requires a string argument.</param>
        /// <returns>Returns an ActionResult.</returns>
        /// <response code="200">When items found.</response>
        /// <response code="400">When items not found.</response> 
        [HttpGet("{accountNumber}")]
        [ProducesResponseType(typeof(IEnumerable<AccountTransaction>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult GetTransactions(String accountNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(accountNumber))
                    return BadRequest("Invalid Request");
                var transactions = _service.GetTransactionsByAccountNumber(accountNumber);
                if (transactions != null && transactions.Count() > 0)
                    return Ok(transactions);
                else
                    return NotFound("No Records Found");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message.ToString());
                return BadRequest(e.Message.ToString());
            }
        }
    }
}
