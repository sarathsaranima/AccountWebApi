using AccountWebApi.Contract.Contracts;
using AccountWebApi.Entities.Context;
using AccountWebApi.Entities.Model;
using AccountWebApi.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace AccountWebApi.Service.Services
{
    /// <summary>
    /// This class defines all the operations perofomed on account.
    /// </summary>
    public class AccountServices : IAccountService
    {
        // Variable for DBContext
        private readonly AccountDbContext _context;

        /// <summary>
        /// Constructor for AccountServices
        /// </summary>
        /// <param name="context"></param>
        public AccountServices(AccountDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method takes the customerID and returns all accounts related to a customer.
        /// </summary>
        /// <param name="customerId">Requires an integer argument</param>
        /// <returns>Returns IEnumerable of Account</returns>
        public IEnumerable<Account> GetAccountsByCustomerId(int customerId)
        {
            if (customerId <= 0)
                throw new CustomAccountException(400, "Invalid Request");
            var accounts = _context.Accounts.Where(x => x.CustomerId == customerId);
            if (accounts != null && accounts.Count() > 0)
                return accounts;
            else
                throw new CustomAccountException(404, "No Records Found");
        }
    }
}
