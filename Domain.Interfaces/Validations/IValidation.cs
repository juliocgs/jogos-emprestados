using FluentValidation.Results;

namespace Domain.Interfaces.Validations
{
    public interface IValidation<T> where T : class
    {
        ValidationResult Validate(T instance);
        void BaseValidation();
    }
}
