using AccountWebApi.Contract.Contracts;
using AccountWebApi.Entities.Context;
using AccountWebApi.Entities.Model;
using AccountWebApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountWebApi.Service.Services
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
        /// This method takes the account number and returns all transaction related to the 
        /// account number.
        /// </summary>
        /// <param name="accountNumber">Requires a string argument</param>
        /// <returns>Returns an IEnumerable of AccountTransaction</returns>
        public IEnumerable<AccountTransaction> GetTransactionsByAccountNumber(String accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
                throw new CustomAccountException(400, "Invalid Request");
            var transactions = _context.Transactions.Where(x => x.AccountNumber == accountNumber);
            if (transactions != null && transactions.Count() > 0)
                return transactions;
            else
                throw new CustomAccountException(404, "No Records Found");
        }
    }
}
