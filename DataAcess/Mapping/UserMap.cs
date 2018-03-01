using Domain.Models;
using FluentNHibernate.Mapping;

namespace Infra.Data.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("app_user");

            Id(u => u.Id, "id").GeneratedBy.Guid();
            Map(u => u.UserName, "username").Length(10).Not.Nullable();
            Map(u => u.Password, "password").Length(36).Not.Nullable();
            Map(u => u.RegistrationDate, "registration_date").Not.Nullable();
            Map(u => u.LastLogin, "last_login").Nullable();
        }
    }
}
