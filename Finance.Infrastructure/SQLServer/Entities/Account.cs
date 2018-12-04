using System;

namespace Finance.Infrastructure.SQLServer.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
    }
}
