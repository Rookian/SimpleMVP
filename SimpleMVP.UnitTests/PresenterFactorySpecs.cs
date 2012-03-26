using System;
using Core;
using FakeItEasy;
using Machine.Specifications;
using SimpleMvp.Infrastructure;
using SimpleMvp.Infrastructure.Bases;

namespace SimpleMVP.UnitTests
{
    [Subject(typeof(PresenterFactory<>))]
    public class When_creating_a_presenter_without_a_ctor_parameter
    {
        static PresenterFactory<IPresenter<IView>> PresenterFactory;
        static IPresenter<IView> Presenter;
        static IView View;
        static IUnitOfWork UnitOfWork;

        Establish context = () =>
        {
            View = A.Fake<IView>();
            UnitOfWork = A.Fake<IUnitOfWork>();
            Func<Type, IPresenter<IView>> a = type => new TestPresenter(View, UnitOfWork);
            Func<Type, object, IPresenter<IView>> b = (type, param) => new TestPresenter(View, UnitOfWork);
            PresenterFactory = new PresenterFactory<IPresenter<IView>>(a, b);
        };

        Because of = () =>
        {
            Presenter = PresenterFactory.Create();
        };

        It should_create_the_presenter_correctly = () =>
        {
            Presenter.ShouldNotBeNull();
            Presenter.ShouldBeOfType<TestPresenter>();
        };
    }
}