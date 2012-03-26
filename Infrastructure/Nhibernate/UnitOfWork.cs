using Core.Common;
using NHibernate;

namespace Infrastructure.Nhibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ISession _session;

        public UnitOfWork(ISession session)
        {
            _session = session;
            Ensure.That(session).IsNotNull();

            _session.BeginTransaction();
        }

        public void RollBack()
        {
            if (GetTransaction().IsActive)
            {
                GetTransaction().Rollback();
            }
        }

        public void Dispose()
        {
            _session.Dispose();
        }

        public void Commit()
        {
            var transaction = GetTransaction();
            transaction.Commit();
        }

        ITransaction GetTransaction()
        {
            return _session.Transaction;
        }
    }
}