using Finance.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Finance.Domain.Customers
{
    public sealed class Customer : IEntity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public CPF CPF { get; private set; }
        public IReadOnlyCollection<Guid> Accounts
        {
            get
            {
                IReadOnlyCollection<Guid> readOnly = _accounts.GetAccountIds();
                return readOnly;
            }
        }

        private AccountCollection _accounts;

        public Customer(CPF cpf, Name name)
        {
            Id = Guid.NewGuid();
            CPF = cpf;
            Name = name;
            _accounts = new AccountCollection();
        }

        public void Register(Guid accountId)
        {
            _accounts.Add(accountId);
        }

        private Customer() { }

        public static Customer Load(Guid id, Name name, CPF cpf, AccountCollection accounts)
        {
            Customer customer = new Customer();
            customer.Id = id;
            customer.Name = name;
            customer.CPF = cpf;
            customer._accounts = accounts;
            return customer;
        }
    }
}
