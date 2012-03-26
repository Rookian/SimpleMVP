using FakeItEasy;
using Infrastructure.Nhibernate;
using Machine.Specifications;
using NHibernate;
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
        static ISession Session;

        Establish context = () =>
                                {
                                    Session = A.Fake<ISession>();
                                    UnitOfWork = A.Fake<UnitOfWork>(a => new UnitOfWork(Session));
                                    View = A.Fake<IView>();
                                    Presenter = A.Fake<Presenter<IView>>();
                                };

        Because of = () => Presenter.Dispose();

        It should_dispose_the_unit_of_work = () => A.CallTo(() => UnitOfWork.Dispose()).MustHaveHappened();
    }
}