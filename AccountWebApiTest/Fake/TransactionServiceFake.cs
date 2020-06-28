using System;
using System.Collections.Generic;
using System.Text;
using AccountWebApi.Model;
using System.Linq;
using AccountWebApi.Contract;

namespace AccountWebApiTest.Fake
{
    /// <summary>
    /// Mock class that would be injected to test TransactionServiceController.
    /// </summary>
    class TransactionServiceFake : ITransactionService
    {
        private readonly List<AccountTransaction> _transactions;

        /// <summary>
        /// Constructor for TransactionServiceFake, mocking some test data.
        /// </summary>
        public TransactionServiceFake()
        {
            _transactions = new List<AccountTransaction>()
            {
                new AccountTransaction
                {
                    Id = 1,
                    AccountNumber = "123-2223-212",
                    AccountName = "Current Account",
                    Currency = "SGD",
                    TransactionType = "Credit",
                    Amount = 9540.98
                },
                new AccountTransaction
                {
                    Id = 2,
                    AccountNumber = "123-2223-212",
                    AccountName = "Current Account",
                    Currency = "SGD",
                    TransactionType = "Credit",
                    Amount = 123.98
                }
            };
        }
        
        /// <summary>
        /// Mock method to test get by id operation.
        /// </summary>
        /// <param name="accountNumber">Requires a string argument</param>
        /// <returns>Returns an IEnumerable of AccountTransaction</returns>
        public IEnumerable<AccountTransaction> GetTransactionsByAccountNumber(String accountNumber)
        {
            return _transactions.Where(a => a.AccountNumber == accountNumber);
        }
    }
}
