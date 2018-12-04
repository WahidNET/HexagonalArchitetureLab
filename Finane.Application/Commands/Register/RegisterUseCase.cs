using Finance.Application.Repositories;
using Finance.Domain.Accounts;
using Finance.Domain.Customers;
using System.Threading.Tasks;

namespace Finance.Application.Commands.Register
{
    public sealed class RegisterUseCase : IRegisterUseCase
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public RegisterUseCase(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public async Task<RegisterResult> Execute(string cpf, string name, double initialAmount)
        {
            Customer customer = new Customer(cpf, name);

            Account account = new Account(customer.Id);
            account.Deposit(initialAmount);
            Credit credit = (Credit)account.GetLastTransaction();

            customer.Register(account.Id);

            await customerWriteOnlyRepository.Add(customer);
            await accountWriteOnlyRepository.Add(account, credit);

            RegisterResult result = new RegisterResult(customer, account);
            return result;
        }
    }
}
