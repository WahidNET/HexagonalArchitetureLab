using Finance.Domain.Accounts;
using System;
using System.Threading.Tasks;

namespace Finance.Application.Repositories
{
    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);
    }
}
