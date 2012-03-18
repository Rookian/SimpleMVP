using System;
using SimpleMvp.Bases;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Presenters
{
    public class DetailViewPresenter : Presenter<IDetailView>
    {
        private readonly IDetailView _view;

        public DetailViewPresenter(IDetailView view, ArticleViewModel article) : base(view)
        {
            _view = view;
            _view.ShowDetails(new ArticleViewModel { Id = article.Id, Name = article.Name });
            _view.CloseClick += View_CloseClick;
        }

        private void View_CloseClick(object sender, EventArgs eventArgs)
        {
            _view.Close();
        }

        public override void Dispose()
        {
            _view.CloseClick -= View_CloseClick;
        }
    }
}