using Domain.Interfaces;
using Infra.Data.UoW;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UnitOfWork _uow;

        public Repository(IUnitOfWork uow)
        {
            _uow = (UnitOfWork)uow;
        }

        protected ISession Session { get { return _uow.Session; } }

        public IList<T> GetAll()
        {
            return Session.Query<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return Session.Get<T>(id);
        }

        public void Create(T entity)
        {
            Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Flush();
            Session.Clear();
            Session.Update(entity);
        }

        public void Delete(Guid id)
        {
            Session.Delete(Session.Load<T>(id));
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }


}
