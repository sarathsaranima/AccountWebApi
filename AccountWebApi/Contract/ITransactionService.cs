using AccountWebApi.Model;
using System;
using System.Collections.Generic;


namespace AccountWebApi.Contract
{
    /// <summary>
    /// This is the contract defining transaction related Operations.
    /// </summary>
    public interface ITransactionService
    {
        IEnumerable<AccountTransaction> GetTransactionsByAccountNumber(String accountNumber);
    }
}
