using Application.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFriendService
    {

        /// <summary>
        /// Returns all data of <see cref="Application.Models.FriendViewModel"/> from database
        /// </summary>
        /// <returns></returns>
        IList<FriendViewModel> GetAll();

        /// <summary>
        /// Returns <see cref="Application.Models.FriendViewModel"/> by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FriendViewModel GetById(Guid id);

        /// <summary>
        /// Saves a new <see cref="Application.Models.FriendViewModel"/> to database
        /// </summary>
        /// <param name="friend"></param>
        ValidationResult Create(FriendViewModel friend);

        /// <summary>
        /// Updates an existings <see cref="Application.Models.FriendViewModel"/> to database
        /// </summary>
        /// <param name="friend"></param>
        ValidationResult Update(FriendViewModel friend);

        /// <summary>
        /// Deletes an existing <see cref="Application.Models.FriendViewModel"/> from database by it's id
        /// </summary>
        /// <param name="id"></param>
        ValidationResult Delete(Guid id);

        /// <summary>
        /// Returns all <see cref="Application.Models.BorrowingViewModel"/> a friend has
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<BorrowingViewModel> GetBorrowedGamesByFriendId(Guid id);
    }
}
