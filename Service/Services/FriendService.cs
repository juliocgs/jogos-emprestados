using Application.Models;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Validations;
using Domain.Models;
using FluentValidation.Results;
using Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class FriendService : IFriendService
    {
        private readonly IMapper _mapper;
        private readonly IFriendRepository _friendRepository;
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly IFriendValidation _friendValidation;

        public FriendService(IMapper mapper, IFriendRepository friendRepository, IBorrowingRepository borrowingRepository, IFriendValidation friendValidation)
        {
            _mapper = mapper;
            _friendRepository = friendRepository;
            _borrowingRepository = borrowingRepository;
            _friendValidation = friendValidation;
        }

        public ValidationResult Create(FriendViewModel game)
        {
            var friendEntity = _mapper.Map<Friend>(game);

            _friendValidation.BaseValidation();
            var validation = _friendValidation.Validate(friendEntity);

            if (validation.IsValid)
            {
                _friendRepository.BeginTransaction();
                _friendRepository.Create(friendEntity);
                _friendRepository.Commit();
            }

            return validation;
        }

        public ValidationResult Delete(Guid id)
        {
            var friendEntity = new Friend() { Id = id };

            _friendValidation.ValidateIfHasGameBorrowed();
            var validation = _friendValidation.Validate(friendEntity);

            if (validation.IsValid)
            {
                _friendRepository.BeginTransaction();
                _friendRepository.Delete(id);
                _friendRepository.Commit();
            }

            return validation;
        }

        public ValidationResult Update(FriendViewModel friend)
        {
            var friendEntity = _mapper.Map<Friend>(friend);

            _friendValidation.BaseValidation();
            var validation = _friendValidation.Validate(friendEntity);

            if (validation.IsValid)
            {
                _friendRepository.BeginTransaction();
                _friendRepository.Update(friendEntity);
                _friendRepository.Commit();
            }

            return validation;
        }

        public IList<FriendViewModel> GetAll()
        {
            return _mapper.Map<IList<FriendViewModel>>(_friendRepository.GetAll());
        }

        public FriendViewModel GetById(Guid id)
        {
            return _mapper.Map<FriendViewModel>(_friendRepository.GetById(id));
        }

        public List<BorrowingViewModel> GetBorrowedGamesByFriendId(Guid id)
        {
            return _mapper.Map<List<BorrowingViewModel>>(_borrowingRepository.GetAllBorrowedGamesByFriendId(id));
        }
    }
}
