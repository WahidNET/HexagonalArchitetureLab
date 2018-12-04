using System;

namespace Finance.Domain
{
    internal interface IAggregateRoot : IEntity
    {
        Guid Id { get; }
    }
}
