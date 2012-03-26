using System;
using SimpleMvp.Bases;

namespace SimpleMvp.Common
{
    public class PresenterFactory<TPresenter> : IPresenterFactory<TPresenter> where TPresenter : IPresenter<IView>
    {
        private readonly Func<Type, object, IPresenter<IView>> _getPresenterWithCtorParameter;
        private readonly Func<Type, IPresenter<IView>> _getPresenter;

        public PresenterFactory(Func<Type, IPresenter<IView>> getPresenter, 
            Func<Type, object, IPresenter<IView>> getPresenterWithCtorParameter)
        {
            _getPresenterWithCtorParameter = getPresenterWithCtorParameter;
            _getPresenter = getPresenter;
        }

        public TPresenter Create(object ctorParameter) 
        {
            return (TPresenter) _getPresenterWithCtorParameter(typeof (TPresenter), ctorParameter);
        }

        public TPresenter Create()
        {
            return (TPresenter) _getPresenter(typeof(TPresenter));
        } 
    }
}