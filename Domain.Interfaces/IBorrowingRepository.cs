using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBorrowingRepository : IRepository<Borrowing>
    {

        /// <summary>
        /// Returns all <see cref="Domain.Models.Borrowing"/> a friend has
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Borrowing> GetAllBorrowedGamesByFriendId(Guid id);
    }
}
