using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Returns all data of <see cref="{T}"/> from database
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();

        /// <summary>
        /// Returns <see cref="{T}"/> by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// Saves a new <see cref="{T}"/> to database
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// Updates an existings <see cref="{T}"/> to database
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Deletes an existing <see cref="{T}"/> from database by it's id
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);

        /// <summary>
        /// Begins a database transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commits a database transaction
        /// </summary>
        void Commit();
    }
}
