﻿using System;

namespace Finance.Service.Model
{
    public sealed class TransactionModel
    {
        public double Amount { get; }
        public string Description { get; }
        public DateTime TransactionDate { get; }
        public TransactionModel(double amount, string description, DateTime transactionDate)
        {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
        }
    }
}
