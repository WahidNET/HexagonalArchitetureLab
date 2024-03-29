﻿using Finance.Application.Repositories;
using Finance.Domain.Accounts;
using Finance.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Finance.Application.Commands.Withdraw
{
    public sealed class WithdrawUseCase : IWithdrawUseCase
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public WithdrawUseCase(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public async Task<WithdrawResult> Execute(Guid accountId, Amount amount)
        {
            Account account = await accountReadOnlyRepository.Get(accountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists or is already closed.");

            account.Withdraw(amount);
            Debit debit = (Debit)account.GetLastTransaction();

            await accountWriteOnlyRepository.Update(account, debit);

            WithdrawResult result = new WithdrawResult(
                debit,
                account.GetCurrentBalance()
            );

            return result;
        }
    }
}
