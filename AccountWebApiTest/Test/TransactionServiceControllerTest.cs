using AccountWebApi.Contract.Contracts;
using AccountWebApi.Controllers;
using AccountWebApi.Entities.Model;
using AccountWebApi.Logger.Contract;
using AccountWebApi.Logger.Service;
using AccountWebApiTest.Fake;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using Xunit;

namespace AccountWebApiTest.Test
{
    /// <summary>
    /// Test class to test TransactionServiceController.
    /// </summary>
    public class TransactionServiceControllerTest
    {
        TransactionServiceController _controller;
        ITransactionService _service;
        ILoggerManager _logger = new LoggerManager();

        public TransactionServiceControllerTest()
        {
            _service = new TransactionServiceFake();
            _controller = new TransactionServiceController(_logger, _service);
        }

        [Fact]
        public void GetByAccount_UnknownAccount_ReturnsNoResult()
        {
            // Act
            var notFoundResult = _controller.GetTransactions("xxxxxxxxxx") as ActionResult<List<AccountTransaction>>;
            var result = notFoundResult.Result as OkObjectResult;
            var transactions = result.Value as List<AccountTransaction>;

            // Assert
            Assert.Empty(transactions);
        }

        [Fact]
        public void GetByAccount_ExistingAccount_ReturnsResult()
        {
            // Arrange
            string accountNbr = "123-2223-212";
            // Act
            var okResult = _controller.GetTransactions(accountNbr) as ActionResult<List<AccountTransaction>>;
            var result = okResult.Result as OkObjectResult;
            var transactions = result.Value as List<AccountTransaction>;

            // Assert
            Assert.NotEmpty(transactions);
        }
    }
}
