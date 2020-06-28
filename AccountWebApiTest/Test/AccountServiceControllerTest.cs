using AccountWebApi.Controllers;
using AccountWebApi.Contract;
using AccountWebApi.Model;
using System.Collections.Generic;
using AccountWebApiTest.Fake;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AccountWebApiTest.Test
{
    /// <summary>
    /// Test class to test AccountServiceController.
    /// </summary>
    public class AccountServiceControllerTest
    {
        AccountServiceController _controller;
        IAccountService _service;
        ILogger<AccountServiceController> _logger = new Logger<AccountServiceController>(new NullLoggerFactory());

        public AccountServiceControllerTest()
        {
            _service = new AccountServiceFake();
            _controller = new AccountServiceController(_logger, _service);
        }

        [Fact]
        public void GetById_UnknownId_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetAccounts(500);

            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAccounts(101);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsAssignableFrom<IEnumerable<Account>>((okResult as OkObjectResult).Value);
        }
    }
}
