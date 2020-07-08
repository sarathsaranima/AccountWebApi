using AccountWebApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountWebApi.Contract.Contracts
{
    /// <summary>
    /// This is the contract defining account related operations.
    /// </summary>
    public interface IAccountService
    {
        IEnumerable<Account> GetAccountsByCustomerId(int customerId);
    }
}
