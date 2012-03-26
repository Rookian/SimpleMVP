using CompositionRoot;
using Machine.Specifications;
using SimpleMvp.Bases;
using SimpleMvp.Infrastructure;
using SimpleMvp.Infrastructure.Bases;
using SimpleMvp.ViewModels;
using StructureMap;

namespace SimpleMVP.IntegrationTests
{
    [Subject(typeof(PresenterFactory<>))]
    public class When_creating_a_presenter_without_ctor_parameters
    {
        static IPresenterFactory<IPresenter<IMainView>> PresenterFactory;
        static IPresenter<IMainView> Presenter;

        Establish context = () =>
        {
            BootsTrapper.Boot();
            PresenterFactory = ObjectFactory.GetInstance<IPresenterFactory<IPresenter<IMainView>>>();
        };

        Because of = () => { Presenter = PresenterFactory.Create(); };

        It should_create_the_presenter = () => Presenter.ShouldNotBeNull();
        It should_get_the_corresponding_view = () => Presenter.CurrentView.ShouldNotBeNull();
    }

    [Subject(typeof(PresenterFactory<>))]
    public class When_creating_a_presenter_with_ctor_parameters
    {
        static IPresenterFactory<IPresenter<IDetailView>> PresenterFactory;
        static IPresenter<IDetailView> Presenter;
        static ArticleViewModel ViewModel;

        Establish context = () =>
        {
            BootsTrapper.Boot();
            PresenterFactory = ObjectFactory.GetInstance<IPresenterFactory<IPresenter<IDetailView>>>();
            ViewModel = new ArticleViewModel { Id = 99, Name = "Test" };
        };

        Because of = () => { Presenter = PresenterFactory.Create(ViewModel); };

        It should_create_the_presenter = () => Presenter.ShouldNotBeNull();
        It should_get_the_corresponding_view = () => Presenter.CurrentView.ShouldNotBeNull();
        It should_inject_the_ctor_parameter = () => Presenter.GetField<ArticleViewModel>().ShouldEqual(ViewModel);
    }
}
