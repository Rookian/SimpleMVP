using System;

namespace SimpleMvp.Bases
{
    public interface IPresenter<out TView> : IDisposable
    {
        TView View { get; }
    }
}