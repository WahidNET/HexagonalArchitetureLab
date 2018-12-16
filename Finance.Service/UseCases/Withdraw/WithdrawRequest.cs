using System;

namespace Finance.Service.UseCases.Withdraw
{
    public sealed class WithdrawRequest
    {
        public Guid AccountId { get; set; }
        public Double Amount { get; set; }
    }
}
