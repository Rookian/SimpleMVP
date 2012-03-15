using System;
using System.Linq;
using Core.Repository;
using SimpleMvp.Base;
using SimpleMvp.Model;

namespace SimpleMvp.Presenter
{
    public class MainViewPresenter : IPresenter<IMainView>
    {
        private readonly IArticleRepository _articlesRepository;
        private readonly IPresenterFactory _presenterFactory;
        private readonly IMainView _view;

        public MainViewPresenter(IMainView view, IArticleRepository articlesRepository, IPresenterFactory presenterFactory)
        {
            _view = view;
            _articlesRepository = articlesRepository;
            _presenterFactory = presenterFactory;
            _view.DetailsClick += View_DetailsClick;
            _view.CloseClick += View_CloseClick;
            _view.BindModel(_articlesRepository.GetAll().Select(x => new ArticleViewModel { Id = x.Id, Name = x.Name }));
        }

        public IMainView View
        {
            get { return _view; }
        }

        private void View_CloseClick(object sender, EventArgs e)
        {
            _view.Close();
        }

        private void View_DetailsClick(object sender, EventArgs eventArgs)
        {
            var article = _view.GetSelectedArticle();

            if (article == null)
            {
                return;
            }

            using (var detailPresenter = _presenterFactory.Create<IPresenter<IDetailView>>(article))
            {
                _presenterFactory.ShowDialog(detailPresenter.View, View);
            }
        }

        public void Dispose()
        {
            _view.CloseClick -= View_CloseClick;
            _view.DetailsClick -= View_DetailsClick;
        }
    }
}