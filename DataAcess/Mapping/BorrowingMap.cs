using Domain.Models;
using FluentNHibernate.Mapping;

namespace Infra.Data.Mapping
{
    public class BorrowingMap : ClassMap<Borrowing>
    {
        public BorrowingMap()
        {
            Table("borrowing");

            Id(b => b.Id, "id").GeneratedBy.Guid();
            Map(b => b.BorrowedDate, "borrowed_date").Not.Nullable();
            Map(b => b.ReturnDate, "return_date").Nullable();

            References(b => b.Friend, "friend_id").LazyLoad().Not.Update();
            References(b => b.Game, "game_id").LazyLoad().Not.Update();
        }
    }
}
