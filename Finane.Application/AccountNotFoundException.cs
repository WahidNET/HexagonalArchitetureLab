﻿namespace Finance.Application
{
    internal sealed class AccountNotFoundException : ApplicationException
    {
        internal AccountNotFoundException(string message)
            : base(message)
        { }
    }
}
