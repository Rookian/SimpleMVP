using System;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void RollBack();
    }
}