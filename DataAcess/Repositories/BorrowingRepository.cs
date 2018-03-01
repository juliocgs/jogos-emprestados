using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class BorrowingRepository : Repository<Borrowing>, IBorrowingRepository
    {
        public BorrowingRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public List<Borrowing> GetAllBorrowedGamesByFriendId(Guid id)
        {
            var query = Session.QueryOver<Borrowing>()
                .Where(b => b.Friend.Id == id)
                .OrderBy(b => b.ReturnDate).Desc;

            return query.List().ToList();
        }
    }
}
