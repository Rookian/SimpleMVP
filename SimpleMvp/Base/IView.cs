using System;

namespace SimpleMvp.Base
{
    public interface IView : IDisposable
    {
        event EventHandler CloseClick;
        void Close();
    }
}