using System;
using SimpleMvp.Bases;

namespace SimpleMvp.Common
{
    public class PresenterFactory : IPresenterFactory
    {
        private readonly Func<Type, object, IPresenter<IView>> _getPresenterWithCtorParameter;
        private readonly Func<Type, IPresenter<IView>> _getPresenter;

        public PresenterFactory(Func<Type, IPresenter<IView>> getPresenter, 
            Func<Type, object, IPresenter<IView>> getPresenterWithCtorParameter)
        {
            _getPresenterWithCtorParameter = getPresenterWithCtorParameter;
            _getPresenter = getPresenter;
        }

        public TPresenter Create<TPresenter>(object ctorParameter) where TPresenter : IPresenter<IView>
        {
            return (TPresenter) _getPresenterWithCtorParameter(typeof (TPresenter), ctorParameter);
        }

        public TPresenter Create<TPresenter>()
        {
            return (TPresenter) _getPresenter(typeof(TPresenter));
        } 
    }
}