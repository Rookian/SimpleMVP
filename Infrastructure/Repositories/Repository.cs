using System.Linq;
using Core.DomainModels;
using Core.Repositories;
using NHibernate;

namespace Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        readonly ISession _session;

        protected Repository(ISession session)
        {
            _session = session;
        }

        public virtual void Delete(T entity)
        {
            _session.Delete(entity);
        }

        public virtual T[] GetAll()
        {
            return _session.QueryOver<T>().List<T>().ToArray();
        }

        public virtual T GetById(object id)
        {
            return _session.Get<T>(id);
        }

        public virtual void SaveOrUpdate(T enity)
        {
            _session.SaveOrUpdate(enity);
        }
    }
}