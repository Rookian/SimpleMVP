using FakeItEasy;
using Infrastructure.Nhibernate;
using Machine.Specifications;
using SimpleMvp.Bases;

namespace SimpleMVP.UnitTests
{
    [Subject(typeof(Presenter<>))]
    public class When_disposing_a_presenter
    {
        private class TestPresenter : Presenter<IView>
        {
            public TestPresenter(IView currentView, IUnitOfWork unitOfWork)
                : base(currentView, unitOfWork)
            {

            }

        }

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
}