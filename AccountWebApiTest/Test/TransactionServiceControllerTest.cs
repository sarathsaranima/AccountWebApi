using AccountWebApi.Contract;
using AccountWebApi.Controllers;
using AccountWebApi.Model;
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
        ILogger<TransactionServiceController> _logger = new Logger<TransactionServiceController>(new NullLoggerFactory());

        public TransactionServiceControllerTest()
        {
            _service = new TransactionServiceFake();
            _controller = new TransactionServiceController(_logger, _service);
        }

        [Fact]
        public void GetByAccount_UnknownAccount_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetTransactions("xxxxxxxxxx");

            // Assert
            Assert.NotNull(notFoundResult);
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void GetByAccount_ExistingAccount_ReturnsOkResult()
        {
            // Arrange
            string accountNbr = "123-2223-212";
            // Act
            var okResult = _controller.GetTransactions(accountNbr);

            // Assert
            Assert.NotNull(okResult);
            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsAssignableFrom<IEnumerable<AccountTransaction>>((okResult as OkObjectResult).Value);
        }
    }
}
