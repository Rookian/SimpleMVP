using System;
using SimpleMvp.Base;
using SimpleMvp.Model;

namespace SimpleMvp.Presenter
{
    public class DetailViewPresenter : IPresenter<IDetailView>
    {
        private readonly IDetailView _view;

        public DetailViewPresenter(IDetailView view, ArticleViewModel article)
        {
            _view = view;
            _view.ShowDetails(new ArticleViewModel { Id = article.Id, Name = article.Name });
            _view.CloseClick += View_CloseClick;
        }

        private void View_CloseClick(object sender, EventArgs eventArgs)
        {
            _view.Close();
        }

        public void Dispose()
        {
            _view.CloseClick -= View_CloseClick;
        }

        public IDetailView View
        {
            get { return _view; }
        }
    }
}