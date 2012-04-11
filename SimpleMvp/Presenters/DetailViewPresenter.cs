using System;
using Core;
using Core.Common;
using SimpleMvp.Bases;
using SimpleMvp.Infrastructure;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Presenters
{
    public class DetailViewPresenter : Presenter<IDetailView>
    {
        readonly IDetailView _currentView;
        ArticleViewModel _article;

        public DetailViewPresenter(IDetailView currentView, ArticleViewModel article, IUnitOfWork unitOfWork) : base(currentView, unitOfWork)
        {
            _article = article;
            _currentView = currentView;

            Ensure.That(article).IsNotNull();
            Ensure.That(currentView).IsNotNull();

            _currentView.ShowDetails();
            _currentView.CloseClick += CurrentViewCloseClick;
        }

        void CurrentViewCloseClick(object sender, EventArgs eventArgs)
        {
            _currentView.Close();
        }

        public override void Dispose()
        {
            base.Dispose();
            _currentView.CloseClick -= CurrentViewCloseClick;
        }
    }
}