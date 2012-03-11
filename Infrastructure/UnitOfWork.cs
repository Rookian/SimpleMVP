using System;
using NHibernate;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;

        public UnitOfWork(ISession session)
        {
            _session = session;
        }

        public void Begin()
        {
            if (ThereIsATransactionInProgress())
            {
                GetTransaction().Dispose();
            }

            GetSession().BeginTransaction();
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
            GetSession().Dispose();
        }

        public void Commit()
        {
            ITransaction transaction = GetTransaction();
            if (!transaction.IsActive)
                throw new InvalidOperationException("Must call Start() on the unit of work before committing");

            transaction.Commit();
        }

        public ISession GetSession()
        {
            return _session;
        }

        private ITransaction GetTransaction()
        {
            return GetSession().Transaction;
        }

        private bool ThereIsATransactionInProgress()
        {
            return GetTransaction().IsActive || GetTransaction().WasCommitted || GetTransaction().WasRolledBack;
        }
    }
}