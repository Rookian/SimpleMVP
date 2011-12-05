using System;

namespace SimpleMvp
{
  public interface IPresenter<out TView> : IDisposable
  {
       TView View { get; }
  }
}