namespace Finance.Application
{
    internal sealed class CustomerNotFoundException : ApplicationException
    {
        internal CustomerNotFoundException(string message)
            : base(message)
        { }
    }
}
