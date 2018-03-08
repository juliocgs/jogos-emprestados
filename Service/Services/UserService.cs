using Application.Models;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Validations;
using Domain.Models;
using FluentValidation.Results;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserValidation _userValidation;

        public UserService(IUserRepository userRepository, IUserValidation userValidation)
        {
            _userRepository = userRepository;
            _userValidation = userValidation;
        }

        public UserViewModel GetByUserName(string userName)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetByUserName(userName));
        }

        public ValidationResult ValidateLogin(UserViewModel user)
        {
            _userValidation.ValidateLogin(user.Password);
            var validation = _userValidation.Validate(new User() { UserName = user.UserName });

            if (validation.IsValid)
            {
                _userRepository.BeginTransaction();
                var userEntity = _userRepository.GetByUserName(user.UserName);

                user.LastLogin = userEntity.LastLogin;
                userEntity.LastLogin = DateTime.Now;

                _userRepository.Update(userEntity);
                _userRepository.Commit();
            }

            return validation;
        }
    }
}
