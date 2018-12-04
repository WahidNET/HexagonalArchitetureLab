using System.Threading.Tasks;

namespace Finance.Application.Commands.Register
{
    public interface IRegisterUseCase
    {
        Task<RegisterResult> Execute(string cpf, string name, double initialAmount);
    }
}
