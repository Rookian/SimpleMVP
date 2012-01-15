using System;

namespace SimpleMvp
{
    public class DetailViewPresenter : IPresenter<IDetailView>
    {
        private readonly IDetailView _view;

        public DetailViewPresenter(IDetailView view, string article)
        {
            _view = view;
            _view.ShowDetails(article);
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