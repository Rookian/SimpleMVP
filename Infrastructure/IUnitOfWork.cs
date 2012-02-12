using System;

namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Commit();
        void RollBack();
    }
}