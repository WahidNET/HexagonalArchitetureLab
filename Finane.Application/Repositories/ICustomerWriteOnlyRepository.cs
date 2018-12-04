using Finance.Domain.Customers;
using System.Threading.Tasks;

namespace Finance.Application.Repositories
{
    public interface ICustomerWriteOnlyRepository
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
    }
}
