namespace Finance.Domain.ValueObjects
{
    public struct CPF
    {
        private string _cpfValue;

        public CPF(string cpfValue)
        {
            this._cpfValue = cpfValue;

            if (string.IsNullOrEmpty(_cpfValue) || string.IsNullOrWhiteSpace(_cpfValue))
                throw new CPFShouldNotBeEmptyException("The 'CPF' field is required");

            if(!IsValidCPF())
                throw new CPFInvalidFormatException("Invalid 'CPF' format.");
        }

        bool IsValidCPF()
        {
            return true;
        }

        public override string ToString()
        {
            return _cpfValue.ToString();
        }

        public static implicit operator CPF(string text)
        {
            return new CPF(text);
        }

        public static implicit operator string(CPF cpf)
        {
            return cpf._cpfValue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return obj.ToString() == _cpfValue;
            }

            return ((CPF)obj)._cpfValue == _cpfValue;
        }

        public override int GetHashCode()
        {
            return _cpfValue.GetHashCode();
        }
    }
}
