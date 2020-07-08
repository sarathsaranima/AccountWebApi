using AccountWebApi.Controllers;
using System.Collections.Generic;
using AccountWebApiTest.Fake;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using AccountWebApi.Contract.Contracts;
using AccountWebApi.Entities.Model;
using AccountWebApi.Logger.Contract;
using AccountWebApi.Logger.Service;

namespace AccountWebApiTest.Test
{
    /// <summary>
    /// Test class to test AccountServiceController.
    /// </summary>
    public class AccountServiceControllerTest
    {
        AccountServiceController _controller;
        IAccountService _service;
        ILoggerManager _logger = new LoggerManager();

        public AccountServiceControllerTest()
        {
            _service = new AccountServiceFake();
            _controller = new AccountServiceController(_logger, _service);
        }

        [Fact]
        public void GetById_UnknownId_ReturnsNoResult()
        {
            // Act
            var notFoundResult = _controller.GetAccounts(500) as ActionResult<List<Account>>;
            var result = notFoundResult.Result as OkObjectResult;
            var accounts = result.Value as List<Account>;

            // Assert
            Assert.Empty(accounts);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsResult()
        {
            // Act
            var okResult = _controller.GetAccounts(101) as ActionResult<List<Account>>;
            var result = okResult.Result as OkObjectResult;
            var accounts = result.Value as List<Account>;

            // Assert
            Assert.Equal(2, accounts.Count);
        }
    }
}
