using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFriendRepository : IRepository<Friend>
    {
        /// <summary>
        /// Checks if friend has at least one game borrowed (wheter it's returned or not)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool HasGameBorrowed(Guid id);
    }
}
