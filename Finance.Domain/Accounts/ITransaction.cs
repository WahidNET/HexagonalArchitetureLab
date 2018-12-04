using Finance.Domain.ValueObjects;
using System;

namespace Finance.Domain.Accounts
{
    public interface ITransaction
    {
        Amount Amount { get; }
        string Description { get; }
        DateTime TransactionDate { get; }
    }
}
