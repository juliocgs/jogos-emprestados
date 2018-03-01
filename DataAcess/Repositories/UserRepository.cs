using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public User GetByUserName(string userName)
        {
            var query = Session.QueryOver<User>()
                .Where(u => u.UserName == userName);

            return query.SingleOrDefault();
        }
    }
}
