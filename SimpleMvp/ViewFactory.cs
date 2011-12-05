using System;
using System.Windows.Forms;

namespace SimpleMvp
{
    public class ViewFactory : IViewFactory
    {
        private readonly Func<Type, ConstructorParameter, IPresenter<IView>> _getPresenter;

        public ViewFactory(Func<Type, ConstructorParameter, IPresenter<IView>> getPresenter)
        {
            _getPresenter = getPresenter;
        }

        public TView Create<TView>(ConstructorParameter constructorParameterArgument)
        {
            var presenter =  _getPresenter(typeof(IPresenter<TView>), constructorParameterArgument);
            return (TView)presenter.View;
        }

        public void ShowDialog(IView newForm, object parent)
        {
            var theForm = newForm;
            theForm.ShowDialog((IWin32Window)parent);
        }
    }
}