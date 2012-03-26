using System;
using Infrastructure.Nhibernate;
using SimpleMvp.Bases;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Presenters
{
    public class DetailViewPresenter : Presenter<IDetailView>
    {
        private readonly IDetailView _currentView;

        public DetailViewPresenter(IDetailView currentView, ArticleViewModel article, IUnitOfWork unitOfWork) : base(currentView, unitOfWork)
        {
            _currentView = currentView;
            _currentView.ShowDetails(new ArticleViewModel { Id = article.Id, Name = article.Name });
            _currentView.CloseClick += CurrentViewCloseClick;
        }

        private void CurrentViewCloseClick(object sender, EventArgs eventArgs)
        {
            _currentView.Close();
        }

        public override void Dispose()
        {
            _currentView.CloseClick -= CurrentViewCloseClick;
        }
    }
}