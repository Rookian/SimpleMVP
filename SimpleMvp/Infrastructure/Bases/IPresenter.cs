using System;

namespace SimpleMvp.Infrastructure.Bases
{
    public interface IPresenter<out TView> : IDisposable
    {
        TView CurrentView { get; }
    }
}