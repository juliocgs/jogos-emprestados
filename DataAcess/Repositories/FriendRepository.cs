using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        public FriendRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public bool HasGameBorrowed(Guid id)
        {
            Borrowing borrowingAlias = null;

            var query = Session.QueryOver<Friend>()
                .Inner.JoinAlias(f => f.Borrowings, () => borrowingAlias)
                .Where(f => f.Id == id);

            return query.RowCount() > 0; ;
        }
    }
}
