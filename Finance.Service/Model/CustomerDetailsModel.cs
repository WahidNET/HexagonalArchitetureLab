using System;
using System.Collections.Generic;

namespace Finance.Service.Model
{
    public sealed class CustomerDetailsModel
    {
        public Guid CustomerId { get; }
        public string CPF { get; }
        public string Name { get; }
        public List<AccountDetailsModel> Accounts { get; }

        public CustomerDetailsModel(Guid customerId, string cpf, string name, List<AccountDetailsModel> accounts)
        {
            CustomerId = customerId;
            CPF = cpf;
            Name = name;
            Accounts = accounts;
        }
    }
}
