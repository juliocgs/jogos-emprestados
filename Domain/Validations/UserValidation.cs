using Domain.Interfaces;
using Domain.Interfaces.Validations;
using Domain.Models;
using FluentValidation;
using Infra.Resources;
using System;
using System.Security.Cryptography;

namespace Domain.Validations
{
    public class UserValidation : AbstractValidator<User>, IUserValidation
    {
        private readonly IUserRepository _userRepository;

        public UserValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void BaseValidation()
        {
        }

        public void ValidateLogin(string password)
        {
            RuleFor(user => user.UserName)
                .Custom((userName, context) =>
                {
                    var user = _userRepository.GetByUserName(userName);

                    if (user == null)
                    {
                        context.AddFailure(Messages.USER_LOGIN_ERROR);
                        return;
                    }

                    byte[] hashBytes = Convert.FromBase64String(user.Password);
                    byte[] salt = new byte[16];

                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    var rfc = new Rfc2898DeriveBytes(password, salt, 10000);
                    byte[] hash = rfc.GetBytes(20);

                    if (!ValidateHash(hashBytes, hash))
                        context.AddFailure(Messages.USER_LOGIN_ERROR);
                });
        }

        private bool ValidateHash(byte[] hashBytes, byte[] hash)
        {
            bool valid = true;

            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    valid = false;

            return valid;
        }
    }
}
