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
    public class AccountServiceController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly ILogger<AccountServiceController> _logger;

        /// <summary>
        /// Constructor for AccountServiceController.
        /// </summary>
        /// <param name="serviceContext">Requires an implementation of IAccountService.</param>
        /// <param name="logger">Requires an implementation of ILogger.</param>
        public AccountServiceController(ILogger<AccountServiceController> logger, IAccountService serviceContext)
        {
            _service = serviceContext;
            _logger = logger;
        }

        /// <summary>
        /// Get method to retreive account by customer id.
        /// </summary>
        /// <param name="customerId">Requires an integer argument.</param>
        /// <returns>Returns an ActionResult.</returns>
        /// <response code="200">When items found.</response>
        /// <response code="404">When items not found.</response> 
        /// <response code="400">When inout is not valid.</response> 
        [HttpGet("{customerId}")]
        [ProducesResponseType(typeof(IEnumerable<Account>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult GetAccounts(int customerId)
        {
            try
            {
                if (customerId <= 0)
                    return BadRequest("Invalid Request");
                var accounts = _service.GetAccountsByCustomerId(customerId);
                if (accounts != null && accounts.Count() > 0)
                    return Ok(accounts);
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
