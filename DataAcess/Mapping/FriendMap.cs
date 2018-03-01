using Domain.Models;
using FluentNHibernate.Mapping;

namespace Infra.Data.Mapping
{
    public class FriendMap : ClassMap<Friend>
    {
        public FriendMap()
        {
            Table("friend");

            Id(f => f.Id, "id").GeneratedBy.Guid();
            Map(f => f.Name, "name").Length(120).Not.Nullable();
            Map(f => f.NickName, "nickname").Length(120).Nullable();
            Map(f => f.Email, "email").Length(150).Nullable();
            Map(f => f.PhoneNumber, "phone_number").Precision(11).Scale(0).Nullable();

            HasMany(f => f.Borrowings).KeyColumn("friend_id").LazyLoad().Not.KeyUpdate();
        }
    }
}
