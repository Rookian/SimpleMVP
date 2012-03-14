using System;

namespace SimpleMvp.Base
{
    public interface IPresenter<out TView> : IPresenter
    {
        TView View { get; }
    }

    public interface IPresenter : IDisposable
    {
        
    }
}