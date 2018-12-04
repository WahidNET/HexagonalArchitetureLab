namespace Finance.Domain.ValueObjects
{
    public sealed class CPFShouldNotBeEmptyException : DomainException
    {
        internal CPFShouldNotBeEmptyException(string message)
            :base(message)
        {

        }
    }
}
