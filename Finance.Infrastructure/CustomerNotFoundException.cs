namespace Finance.Infrastructure
{
    public class CustomerNotFoundException : InfrastructureException
    {
        internal CustomerNotFoundException(string message)
            : base(message)
        { }
    }
}
