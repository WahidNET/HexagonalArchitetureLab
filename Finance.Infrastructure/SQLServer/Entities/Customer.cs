﻿using System;

namespace Finance.Infrastructure.SQLServer.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
    }
}
