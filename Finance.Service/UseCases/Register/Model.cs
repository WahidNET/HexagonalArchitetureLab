using Finance.Service.Model;
using System;
using System.Collections.Generic;

namespace Finance.Service.UseCases.Register
{
    internal sealed class Model
    {
        public Guid CustomerId { get; }
        public string CPF { get; }
        public string Name { get; }
        public List<AccountDetailsModel> Accounts { get; set; }

        public Model(Guid customerId, string cpf, string name, List<AccountDetailsModel> accounts)
        {
            CustomerId = customerId;
            CPF = cpf;
            Name = name;
            Accounts = accounts;
        }
    }
}
