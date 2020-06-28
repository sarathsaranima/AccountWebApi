using AccountWebApi.Contract;
using AccountWebApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace AccountWebApi.Services
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
            return _context.Accounts.Where(x => x.CustomerId == customerId);
        }
    }
}



 
