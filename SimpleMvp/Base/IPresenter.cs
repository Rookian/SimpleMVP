using System;

namespace SimpleMvp.Base
{
    public interface IPresenter<out TView> :  IDisposable
    {
        TView View { get; }
    }
}