using System;
using Core;

namespace SimpleMvp
{
    public class MainViewPresenter : IPresenter<IMainView>
    {
        private readonly IArticleRepository _articles;
        private readonly IPresenterFactory _presenterFactory;
        private readonly IMainView _view;

        public MainViewPresenter(IMainView view, IArticleRepository articles, IPresenterFactory presenterFactory)
        {
            _view = view;
            _articles = articles;
            _presenterFactory = presenterFactory;
            _view.DetailsClick += View_DetailsClick;
            _view.CloseClick += View_CloseClick;
            _view.ShowArticles(_articles.GetAll());
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