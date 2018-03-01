using Domain.Models;

namespace Domain.Interfaces.Validations
{
    public interface IGameValidation : IValidation<Game>
    {
        void ValidateIfBorrowed();
    }
}
