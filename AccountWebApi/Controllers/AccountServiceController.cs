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
    /// Defines the AccountServiceController.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountServiceController : ControllerBase
    {
        /// <summary>
        /// Defines the _service.
        /// </summary>
        private readonly IAccountService _service;

        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILoggerManager _logger;

        /// <summary>
        /// Initializes a new instance of the AccountServiceController class.
        /// </summary>
        /// <param name="logger">Requires an implementation of ILoggerManager.</param>
        /// <param name="serviceContext">Requires an implementation of IAccountService.</param>
        public AccountServiceController(ILoggerManager logger, IAccountService serviceContext)
        {
            _service = serviceContext;
            _logger = logger;
        }

        /// <summary>
        /// Get method to retrieve account by customer id.
        /// </summary>
        /// <param name="customerId">Requires an integer argument.</param>
        /// <returns>Returns an ActionResult.</returns>
        [HttpGet("{customerId}")]
        [ProducesResponseType(typeof(IEnumerable<Account>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<List<Account>> GetAccounts(int customerId)
        {
            _logger.LogInfo($"Processing Get GetAccounts for : {customerId}");
            var accounts = _service.GetAccountsByCustomerId(customerId);
            return Ok(accounts.ToList<Account>());
        }
    }
}
