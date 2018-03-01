using Domain.Interfaces;
using Domain.Models;
using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public List<Game> GetAllAvailable()
        {
            Game gameAlias = null;

            var subQuery = QueryOver.Of<Borrowing>()
                .Where(b => b.ReturnDate == null && b.Game.Id == gameAlias.Id)
                .Select(b => b.Id);

            var query = Session.QueryOver<Game>(() => gameAlias)
                .WithSubquery.WhereNotExists(subQuery);

            return query.TransformUsing(Transformers.DistinctRootEntity).List().ToList();
        }

        public bool IsBorrowed(Guid id)
        {
            Borrowing borrowingAlias = null;

            var query = Session.QueryOver<Game>()
                .Inner.JoinAlias(g => g.Borrowings, () => borrowingAlias)
                .Where(g => g.Id == id);

            return query.RowCount() > 0;
        }
    }
}
