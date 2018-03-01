using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBorrowingService
    {
        /// <summary>
        /// Returns all data of <see cref="Application.Models.BorrowingViewModel"/> from database
        /// </summary>
        /// <returns></returns>
        IList<BorrowingViewModel> GetAll();

        /// <summary>
        /// Returns <see cref="Application.Models.BorrowingViewModel"/> by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BorrowingViewModel GetById(Guid id);

        /// <summary>
        /// Saves a new <see cref="Application.Models.BorrowingViewModel"/> to database
        /// </summary>
        /// <param name="friend"></param>
        void Create(BorrowingViewModel friend);

        /// <summary>
        /// Returns a <see cref="Application.Models.GameViewModel"/> by <see cref="Application.Models.BorrowingViewModel"/> id
        /// </summary>
        /// <param name="friend"></param>
        void ReturnGameByBorrowingId(Guid id);
    }
}
