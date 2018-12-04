namespace Finance.Service.UseCases.Register
{
    public sealed class RegisterRequest
    {
        public string CPF { get; set; }
        public string Name { get; set; }
        public double InitialAmount { get; set; }
    }
}
