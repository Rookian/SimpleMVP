using System;
using System.Linq;
using Core.Repositories;
using Infrastructure.Nhibernate;
using SimpleMvp.Bases;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Presenters
{
    public class MainViewPresenter : Presenter<IMainView>
    {
        private readonly IArticleRepository _articlesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPresenterFactoryForMainViewPresenter _presenterFactory;

        public MainViewPresenter(IMainView currentView, IArticleRepository articlesRepository, IUnitOfWork unitOfWork,
            IPresenterFactoryForMainViewPresenter presenterFactory)
            : base(currentView, unitOfWork)
        {
            _articlesRepository = articlesRepository;
            _unitOfWork = unitOfWork;
            _presenterFactory = presenterFactory;


            CurrentView.DetailsClick += View_DetailsClick;
            CurrentView.CloseClick += View_CloseClick;
            CurrentView.CreateClick += View_CreateClick;
            CurrentView.DeleteClick += View_DeleteClick;
            _unitOfWork.Begin();
            CurrentView.BindModel(_articlesRepository.GetAll().Select(x => new ArticleViewModel { Id = x.Id, Name = x.Name }));
        }

        public override void Dispose()
        {
            CurrentView.CloseClick -= View_CloseClick;
            CurrentView.DetailsClick -= View_DetailsClick;
        }

        private void View_DeleteClick(object sender, EventArgs e)
        {
            var selectedArticle = CurrentView.GetSelectedArticle();
            var article = _articlesRepository.GetById(selectedArticle.Id);
            _articlesRepository.Delete(article);
            _unitOfWork.Commit();
        }

        private void View_CreateClick(object sender, EventArgs e)
        {
            using (var createPresenter = _presenterFactory.CreateCreatePresenter())
            {
                ShowDialog(createPresenter.CurrentView, CurrentView);
            }
        }

        private void View_CloseClick(object sender, EventArgs e)
        {
            CurrentView.Close();
        }

        private void View_DetailsClick(object sender, EventArgs eventArgs)
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