using System;
using System.Windows.Forms;
using SimpleMvp.Base;

namespace SimpleMvp.Presenter
{
    public class PresenterFactory : IPresenterFactory
    {
        private readonly Func<Type, object, IPresenter<IView>> _getPresenter;

        public PresenterFactory(Func<Type, object, IPresenter<IView>> getPresenter)
        {
            _getPresenter = getPresenter;
        }

        public TPresenter Create<TPresenter>(object parameter) where TPresenter : IPresenter<IView>
        {
            return (TPresenter) _getPresenter(typeof (TPresenter), parameter);
        }

        public void ShowDialog(IDetailView newForm, object parent)
        {
            newForm.ShowDialog((IWin32Window) parent);
        }
    }
}