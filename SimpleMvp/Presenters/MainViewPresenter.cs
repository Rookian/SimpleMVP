using System;
using System.Linq;
using Core;
using Core.Common;
using Core.Repositories;
using SimpleMvp.Bases;
using SimpleMvp.Infrastructure;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Presenters
{
    public class MainViewPresenter : Presenter<IMainView>
    {
        readonly IArticleRepository _articlesRepository;
        readonly IMainViewPresenterFacade _presenterFactory;
        readonly IUnitOfWork _unitOfWork;

        public MainViewPresenter(IMainView currentView, IArticleRepository articlesRepository, IUnitOfWork unitOfWork,
                                 IMainViewPresenterFacade presenterFactory)
            : base(currentView, unitOfWork)
        {
            _articlesRepository = articlesRepository;
            _unitOfWork = unitOfWork;
            _presenterFactory = presenterFactory;

            Ensure.That(articlesRepository).IsNotNull();
            Ensure.That(presenterFactory).IsNotNull();

            CurrentView.DetailsClick += View_DetailsClick;
            CurrentView.CloseClick += ViewCloseClick;
            CurrentView.CreateClick += View_CreateClick;
            CurrentView.DeleteClick += View_DeleteClick;

            CurrentView.BindModel(_articlesRepository.GetAll().Select(x => new ArticleViewModel { Id = x.ArticleId, Name = x.Description }));
        }

        public override void Dispose()
        {
            base.Dispose();

            CurrentView.DetailsClick -= View_DetailsClick;
            CurrentView.CloseClick -= ViewCloseClick;
            CurrentView.CreateClick -= View_CreateClick;
            CurrentView.DeleteClick -= View_DeleteClick;
        }

        void View_DeleteClick(object sender, EventArgs e)
        {
            var selectedArticle = CurrentView.GetSelectedArticle();
            var article = _articlesRepository.GetById(selectedArticle.Id);
            _articlesRepository.Delete(article);
            _unitOfWork.Commit();
        }

        void View_CreateClick(object sender, EventArgs e)
        {
            using (var createPresenter = _presenterFactory.CreateCreatePresenter())
            {
                ShowDialog(createPresenter.CurrentView, CurrentView);
            }
        }

        void ViewCloseClick(object sender, EventArgs e)
        {
            CurrentView.Close();
        }

        void View_DetailsClick(object sender, EventArgs eventArgs)
        {
            var article = CurrentView.GetSelectedArticle();

            if (article == null) return;

            using (var detailPresenter = _presenterFactory.CreateDetailPresenter(article))
            {
                ShowDialog(detailPresenter.CurrentView, CurrentView);
            }
        }
    }
}