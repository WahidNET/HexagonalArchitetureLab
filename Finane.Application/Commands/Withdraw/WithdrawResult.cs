using Finance.Application.Results;
using Finance.Domain.Accounts;
using Finance.Domain.ValueObjects;

namespace Finance.Application.Commands.Withdraw
{
    public sealed class WithdrawResult
    {
        public TransactionResult Transaction { get; }
        public double UpdatedBalance { get; }

        public WithdrawResult(Debit transaction, Amount updatedBalance)
        {
            Transaction = new TransactionResult(
                transaction.Description,
                transaction.Amount,
                transaction.TransactionDate);

            UpdatedBalance = updatedBalance;
        }
    }
}
