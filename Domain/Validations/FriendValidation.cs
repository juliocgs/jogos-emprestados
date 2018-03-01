using Domain.Interfaces;
using Domain.Interfaces.Validations;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using Infra.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class FriendValidation : AbstractValidator<Friend>, IFriendValidation
    {
        private IFriendRepository _friendRepository;

        public FriendValidation(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public void BaseValidation()
        {
            ValidateName();
            ValidateNickName();
            ValidateEmail();
        }

        public void ValidateIfHasGameBorrowed()
        {
            RuleFor(game => game.Id)
                .Custom((id, context) =>
                {
                    if (_friendRepository.HasGameBorrowed(id))
                        context.AddFailure(Messages.FRIEND_DELETE);
                });
        }

        private void ValidateName()
        {
            RuleFor(friend => friend.Name)
                .NotEmpty().WithMessage(Messages.FRIEND_NAME_REQUIRED)
                .Length(2, 120).WithMessage(Messages.FRIEND_NAME_LENGTH);

        }

        private void ValidateNickName()
        {
            RuleFor(friend => friend.NickName)
                .Length(2, 120).WithMessage(Messages.FRIEND_NICKNAME_LENGTH);
        }

        private void ValidateEmail()
        {
            RuleFor(friend => friend.Email)
                .EmailAddress().WithMessage(Messages.FRIEND_EMAIL_ERROR);
        }
    }
}
