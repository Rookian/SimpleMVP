using System;

namespace SimpleMvp
{
    public interface IPresenter<out TView> : IPresenter
    {
        TView View { get; }
    }

    public interface IPresenter : IDisposable
    {
        
    }
}