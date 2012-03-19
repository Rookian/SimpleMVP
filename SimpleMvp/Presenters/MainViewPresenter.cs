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
        private readonly IPresenterFactory _presenterFactory;

        public MainViewPresenter(IMainView view, IArticleRepository articlesRepository, IUnitOfWork unitOfWork, IPresenterFactory presenterFactory)
            : base(view)
        {
            _articlesRepository = articlesRepository;
            _unitOfWork = unitOfWork;
            _presenterFactory = presenterFactory;

            View.DetailsClick += View_DetailsClick;
            View.CloseClick += View_CloseClick;
            View.CreateClick += View_CreateClick;
            View.DeleteClick += View_DeleteClick;
            _unitOfWork.Begin();
            View.BindModel(_articlesRepository.GetAll().Select(x => new ArticleViewModel { Id = x.Id, Name = x.Name }));
        }

        public override void Dispose()
        {
            View.CloseClick -= View_CloseClick;
            View.DetailsClick -= View_DetailsClick;
        }

        private void View_DeleteClick(object sender, EventArgs e)
        {
            var selectedArticle = View.GetSelectedArticle();
            var article = _articlesRepository.GetById(selectedArticle.Id);
            _articlesRepository.Delete(article);
            _unitOfWork.Commit();
        }

        private void View_CreateClick(object sender, EventArgs e)
        {
            using (var createPresenter = _presenterFactory.Create<IPresenter<ICreateView>>())
            {
                ShowDialog(createPresenter.View, View);
            }
        }

        private void View_CloseClick(object sender, EventArgs e)
        {
            View.Close();
        }

        private void View_DetailsClick(object sender, EventArgs eventArgs)
        {
            var article = View.GetSelectedArticle();

            if (article == null) return;

            using (var detailPresenter = _presenterFactory.Create<IPresenter<IDetailView>>(article))
            {
                ShowDialog(detailPresenter.View, View);
            }
        }
    }
}