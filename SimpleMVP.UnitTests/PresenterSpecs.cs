using Core;
using FakeItEasy;
using Machine.Specifications;
using SimpleMvp.Infrastructure;
using SimpleMvp.Infrastructure.Bases;

namespace SimpleMVP.UnitTests
{
    [Subject(typeof(Presenter<>))]
    public class When_disposing_a_presenter
    {
        static IUnitOfWork UnitOfWork;
        static Presenter<IView> Presenter;
        static IView View;

        Establish context = () =>
        {
            UnitOfWork = A.Fake<IUnitOfWork>();
            View = A.Fake<IView>();
            Presenter = new TestPresenter(View, UnitOfWork);
        };

        Because of = () => Presenter.Dispose();

        It should_dispose_the_unit_of_work = () => A.CallTo(() => UnitOfWork.Dispose()).MustHaveHappened();
    }

    [Subject(typeof (Presenter<>))]
    public class When_injecting_a_view_into_the_presenter
    {
        static IUnitOfWork UnitOfWork;
        static Presenter<IView> Presenter;
        static IView View;

        Establish context = () =>
        {
            UnitOfWork = A.Fake<IUnitOfWork>();
            View = A.Fake<IView>();

        };

        Because of = () => { Presenter = new TestPresenter(View, UnitOfWork); };

        It should_return_the_injected_View = () => Presenter.CurrentView.ShouldEqual(View);
    }
}