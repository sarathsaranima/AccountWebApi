using System;
using System.Collections.Generic;
using System.Text;
using AccountWebApi.Model;
using System.Linq;
using AccountWebApi.Contract;


namespace AccountWebApiTest.Fake
{
    /// <summary>
    /// Mock class that would be injected to test the AccountServiceController. 
    /// </summary>
    class AccountServiceFake : IAccountService
    {
        private readonly List<Account> _accounts;

        /// <summary>
        /// Constructor for AccountServiceFake, creating mock data.
        /// </summary>
        public AccountServiceFake()
        {
            _accounts = new List<Account>()
            {
                new Account
                {
                    Id = 1,
                    CustomerId = 101,
                    AccountNumber = "585309209",
                    AccountName = "SGSavings726",
                    AccountType = "Savings",
                    Currency = "AUD",
                    Balance = 84327.51
                },
                new Account
                {
                    Id = 2,
                    CustomerId = 101,
                    AccountNumber = "791066619",
                    AccountName = "AUSavings933",
                    AccountType = "Savings",
                    Currency = "AUD",
                    Balance = 88005.93
                }
            };
        }

        /// <summary>
        /// Mock method to test Get by Id operation.
        /// </summary>
        /// <param name="customerId">Requires an integer.</param>
        /// <returns>Returns and IEnumerable of Account.</returns>
        public IEnumerable<Account> GetAccountsByCustomerId(int customerId)
        {
            return _accounts.Where(a => a.CustomerId == customerId);
        }
    }
}
