using System;

namespace SimpleMvp
{
    internal class MainFormPresenter : IPresenter<IMainFormView>
    {
        private readonly IArticleRepository _articles;
        private readonly IViewFactory _views;
        private readonly IMainFormView _view;

        public MainFormPresenter(IMainFormView view, IArticleRepository articles, IViewFactory views)
        {
            _view = view;
            _articles = articles;
            _views = views;

            _view.DetailsClick += View_DetailsClick;
            _view.CloseClick += View_CloseClick;

            _view.ShowArticles(_articles.GetAll());
        }

        public IMainFormView View
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

            var details = _views.Create<IDetailView>(
                new ConstructorParameter { ParameterName = "article", ParameterValue = article });

            _views.ShowDialog(details, View);
        }

        public void Dispose()
        {
            _view.CloseClick -= View_CloseClick;
            _view.DetailsClick -= View_DetailsClick;
        }
    }
}