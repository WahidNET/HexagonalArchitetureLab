using Finance.Application.Results;
using System;
using System.Threading.Tasks;

namespace Finance.Application.Queries
{
    public interface IAccountsQueries
    {
        Task<AccountResult> GetAccount(Guid accountId);
    }
}
