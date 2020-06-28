using AccountWebApi.Contract;
using AccountWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountWebApi.Services
{
    /// <summary>
    /// This class defines all the operations perfomed on transaction.
    /// </summary>
    public class TransactionService : ITransactionService
    {
        // Variable for DBCOntext
        private readonly AccountDbContext _context;

        /// <summary>
        /// Constructor for TransactionService.
        /// </summary>
        /// <param name="context"></param>
        public TransactionService(AccountDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method takes the account number and returns all transaction related to the account number.
        /// </summary>
        /// <param name="accountNumber">Requires a string argument</param>
        /// <returns>Returns an IEnumerable of AccountTransaction</returns>
        public IEnumerable<AccountTransaction> GetTransactionsByAccountNumber(String accountNumber)
        {
            return _context.Transactions.Where(x => x.AccountNumber == accountNumber);
        }
    }
}
