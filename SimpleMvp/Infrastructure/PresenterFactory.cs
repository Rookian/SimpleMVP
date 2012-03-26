using System;
using SimpleMvp.Infrastructure.Bases;

namespace SimpleMvp.Infrastructure
{
    public class PresenterFactory<TPresenter> : IPresenterFactory<TPresenter> where TPresenter : IPresenter<IView>
    {
        readonly Func<Type, IPresenter<IView>> _getPresenter;
        readonly Func<Type, object, IPresenter<IView>> _getPresenterWithCtorParameter;

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
            return (TPresenter) _getPresenter(typeof (TPresenter));
        }
    }
}