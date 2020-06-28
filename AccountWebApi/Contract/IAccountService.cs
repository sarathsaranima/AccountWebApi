using AccountWebApi.Model;
using System.Collections.Generic;

namespace AccountWebApi.Contract
{
    /// <summary>
    /// This is the contract defining account related operations.
    /// </summary>
    public interface IAccountService
    {
        IEnumerable<Account> GetAccountsByCustomerId(int customerId);
    }
}
