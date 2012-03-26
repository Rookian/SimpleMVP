using System;

namespace Infrastructure.Nhibernate
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void RollBack();
    }
}