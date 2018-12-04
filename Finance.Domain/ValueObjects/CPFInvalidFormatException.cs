namespace Finance.Domain.ValueObjects
{
    public sealed class CPFInvalidFormatException : DomainException
    {
        internal CPFInvalidFormatException(string message)
            :base(message)
        {

        }
    }
}
