using Domain.Models;
using FluentNHibernate.Mapping;

namespace Infra.Data.Mapping
{
    public class GameMap : ClassMap<Game>
    {
        public GameMap()
        {
            Table("game");

            Id(g => g.Id, "id").GeneratedBy.Guid();
            Map(g => g.Name, "name").Length(120).Not.Nullable();
            Map(g => g.RegistrationDate, "registration_date").Not.Nullable();
            Map(g => g.Price, "price").CustomSqlType("money").Nullable();

            HasMany(g => g.Borrowings).KeyColumn("game_id").LazyLoad().Not.KeyUpdate();
        }
    }
}
