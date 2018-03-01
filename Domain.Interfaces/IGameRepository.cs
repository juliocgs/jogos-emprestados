using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        /// <summary>
        /// Get all available <see cref="Domain.Models.Game"/> (the ones that are not borrowed)
        /// </summary>
        /// <returns></returns>
        List<Game> GetAllAvailable();

        /// <summary>
        /// Check if a game is borrowed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsBorrowed(Guid id);
    }
}
