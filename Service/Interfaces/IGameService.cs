using Application.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IGameService
    {
        /// <summary>
        /// Returns all data of <see cref="Application.Models.GameViewModel"/> from database
        /// </summary>
        /// <returns></returns>
        IList<GameViewModel> GetAll();

        /// <summary>
        /// Get all available <see cref="Application.Models.GameViewModel"/> (the ones that are not borrowed)
        /// </summary>
        /// <returns></returns>
        List<GameViewModel> GetAllAvailable();

        /// <summary>
        /// Returns <see cref="Application.Models.GameViewModel"/> by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GameViewModel GetById(Guid id);

        /// <summary>
        /// Saves a new <see cref="Application.Models.GameViewModel"/> to database
        /// </summary>
        /// <param name="game"></param>
        ValidationResult Create(GameViewModel game);

        /// <summary>
        /// Updates an existings <see cref="Application.Models.GameViewModel"/> to database
        /// </summary>
        /// <param name="game"></param>
        ValidationResult Update(GameViewModel game);

        /// <summary>
        /// Deletes an existing <see cref="Application.Models.GameViewModel"/> from database by it's id
        /// </summary>
        /// <param name="id"></param>
        ValidationResult Delete(Guid id);
    }
}
