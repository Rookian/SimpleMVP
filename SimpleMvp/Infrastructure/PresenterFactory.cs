using System;
using Core.Common;
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

            Ensure.That(getPresenter).IsNotNull();
            Ensure.That(getPresenterWithCtorParameter).IsNotNull();
        }

        public TPresenter Create(object viewModel)
        {
            var presenterWithCtorParameter = (TPresenter) _getPresenterWithCtorParameter(typeof (TPresenter), viewModel);
            var currentView = presenterWithCtorParameter.CurrentView;
            return presenterWithCtorParameter;
        }

        public TPresenter Create()
        {
            return (TPresenter) _getPresenter(typeof (TPresenter));
        }
    }
}