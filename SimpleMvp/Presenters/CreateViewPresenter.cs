using System;
using Core;
using Core.Common;
using Core.DomainModels;
using Core.Repositories;
using SimpleMvp.Bases;
using SimpleMvp.Infrastructure;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Presenters
{
    public class CreateViewPresenter : Presenter<ICreateView>
    {
        readonly IArticleRepository _articleRepository;
        readonly IUnitOfWork _unitOfWork;

        public CreateViewPresenter(ICreateView currentView, IArticleRepository articleRepository, IUnitOfWork unitOfWork)
            : base(currentView, unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;

            Ensure.That(articleRepository).IsNotNull();
            Ensure.That(unitOfWork).IsNotNull();

            CurrentView.CloseClick += SaveClick;
            CurrentView.BindModel(new ArticleViewModel());
        }

        void SaveClick(object sender, EventArgs e)
        {
            var articleViewModel = CurrentView.GetArticle();

            _articleRepository.SaveOrUpdate(new Article { Description = articleViewModel.Name });
            _unitOfWork.Commit();
            CurrentView.Close();
        }

        public override void Dispose()
        {
            base.Dispose();
            CurrentView.CloseClick -= SaveClick;
        }
    }
}