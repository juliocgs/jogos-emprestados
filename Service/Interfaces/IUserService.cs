using Application.Models;
using FluentValidation.Results;

namespace Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Checks if a login is validy by userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        ValidationResult ValidateLogin(UserViewModel user);

        /// <summary>
        /// Returns <see cref="Application.Models.UserViewModel"/> by it's userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        UserViewModel GetByUserName(string userName);
    }
}
