using Domain.Models;

namespace Domain.Interfaces.Validations
{
    public interface IUserValidation : IValidation<User>
    {
        void ValidateLogin(string password);
    }
}
