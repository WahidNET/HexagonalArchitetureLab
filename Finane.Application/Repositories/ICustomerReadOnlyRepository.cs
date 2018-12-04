using Finance.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace Finance.Application.Repositories
{
    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}
