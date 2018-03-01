using Domain.Interfaces;
using Domain.Interfaces.Validations;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using Infra.Resources;

namespace Domain.Validations
{
    public class GameValidation : AbstractValidator<Game>, IGameValidation
    {
        private readonly IGameRepository _gameRepository;

        public GameValidation(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void BaseValidation()
        {
            ValidateName();
        }

        private void ValidateName()
        {
            RuleFor(game => game.Name)
                .NotEmpty().WithMessage(Messages.GAME_NAME_REQUIRED)
                .Length(2, 120).WithMessage(Messages.GAME_NAME_LENGTH);
        }

        public void ValidateIfBorrowed()
        {
            RuleFor(game => game.Id)
                .Custom((id, context) =>
                {
                    if (_gameRepository.IsBorrowed(id))
                        context.AddFailure(Messages.GAME_DELETE);
                });
        }
    }
}
