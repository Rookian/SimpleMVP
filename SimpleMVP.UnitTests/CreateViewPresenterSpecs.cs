using Core;
using Core.Repositories;
using FakeItEasy;
using Machine.Specifications;
using SimpleMvp.Bases;
using SimpleMvp.Presenters;

namespace SimpleMVP.UnitTests
{
    [Subject(typeof(CreateViewPresenter))]
    public class When_pushing_the_save_button
    {
        static ICreateView CreateView;
        static CreateViewPresenter CreateViewPresenter;
        static IArticleRepository ArticleRepository;
        static IUnitOfWork UnitOfWork;

        Establish context = () =>
                                {
                                    CreateView = A.Fake<ICreateView>();
                                    ArticleRepository = A.Fake<IArticleRepository>();
                                    UnitOfWork = A.Fake<IUnitOfWork>();
                                    CreateViewPresenter = new CreateViewPresenter(CreateView, ArticleRepository, UnitOfWork);
                                };

        Because of = () => { CreateView.CloseClick += Raise.WithEmpty().Now; };

        It should_save_the_article = () => A.CallTo(() => ArticleRepository.SaveOrUpdate(null)).WithAnyArguments().MustHaveHappened();
    }
}