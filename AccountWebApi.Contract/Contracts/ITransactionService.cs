using AccountWebApi.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountWebApi.Contract.Contracts
{
    /// <summary>
    /// This is the contract defining transaction related Operations.
    /// </summary>
    public interface ITransactionService
    {
        IEnumerable<AccountTransaction> GetTransactionsByAccountNumber(String accountNumber);
    }
}
