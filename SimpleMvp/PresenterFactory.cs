using System;
using System.Windows.Forms;

namespace SimpleMvp
{
    public class PresenterFactory : IPresenterFactory
    {
        private readonly Func<Type, ConstructorParameter, IPresenter<IView>> _getPresenter;

        public PresenterFactory(Func<Type, ConstructorParameter, IPresenter<IView>> getPresenter)
        {
            _getPresenter = getPresenter;
        }

        public TPresenter Create<TPresenter>(ConstructorParameter constructorParameterArgument) where TPresenter : IPresenter<IView>
        {
            return (TPresenter)_getPresenter(typeof(TPresenter), constructorParameterArgument);
        }

        public void ShowDialog(IDetailView newForm, object parent)
        {
            newForm.ShowDialog((IWin32Window)parent);
        }
    }
}