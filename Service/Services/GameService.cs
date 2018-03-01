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

namespace Service.Services
{
    public class GameService : IGameService
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly IGameValidation _gameValidation;

        public GameService(IMapper mapper, IGameRepository gameRepository, IGameValidation gameValidation)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
            _gameValidation = gameValidation;
        }

        public ValidationResult Create(GameViewModel game)
        {
            var gameEntity = _mapper.Map<Game>(game);

            _gameValidation.BaseValidation();
            var validation = _gameValidation.Validate(gameEntity);

            if (validation.IsValid)
            {
                _gameRepository.BeginTransaction();
                _gameRepository.Create(gameEntity);
                _gameRepository.Commit();
            }

            return validation;
        }

        public ValidationResult Delete(Guid id)
        {
            var gameEntity = new Game() { Id = id };

            _gameValidation.ValidateIfBorrowed();
            var validation = _gameValidation.Validate(gameEntity);

            if (validation.IsValid)
            {
                _gameRepository.BeginTransaction();
                _gameRepository.Delete(id);
                _gameRepository.Commit();
            }

            return validation;
        }

        public ValidationResult Update(GameViewModel game)
        {
            var gameEntity = _mapper.Map<Game>(game);

            _gameValidation.BaseValidation();
            var validation = _gameValidation.Validate(gameEntity);

            if (validation.IsValid)
            {
                _gameRepository.BeginTransaction();
                gameEntity.RegistrationDate = _gameRepository.GetById(game.Id).RegistrationDate;
                _gameRepository.Update(gameEntity);
                _gameRepository.Commit();
            }

            return validation;
        }

        public IList<GameViewModel> GetAll()
        {
            return _mapper.Map<IList<GameViewModel>>(_gameRepository.GetAll());
        }

        public List<GameViewModel> GetAllAvailable()
        {
            return _mapper.Map<List<GameViewModel>>(_gameRepository.GetAllAvailable());
        }

        public GameViewModel GetById(Guid id)
        {
            return _mapper.Map<GameViewModel>(_gameRepository.GetById(id));
        }
    }
}
