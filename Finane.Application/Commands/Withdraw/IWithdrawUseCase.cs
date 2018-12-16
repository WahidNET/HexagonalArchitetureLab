using Finance.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Finance.Application.Commands.Withdraw
{
    public interface IWithdrawUseCase
    {
        Task<WithdrawResult> Execute(Guid accountId, Amount amount);
    }
}
