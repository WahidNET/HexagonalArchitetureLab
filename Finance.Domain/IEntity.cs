using System;

namespace Finance.Domain
{
    internal interface IEntity
    {
        Guid Id { get; }
    }
}
