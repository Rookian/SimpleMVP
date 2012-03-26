using System;
using Core.DomainModels;
using Core.Repositories;
using Infrastructure.Nhibernate;
using SimpleMvp.Bases;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Presenters
{
    public class CreateViewPresenter : Presenter<ICreateView>
    {
        private readonly IArticleRepository _articleRepository;

        public CreateViewPresenter(ICreateView currentView, IArticleRepository articleRepository, IUnitOfWork unitOfWork)
            : base(currentView, unitOfWork)
        {
            _articleRepository = articleRepository;
            CurrentView.CloseClick += SaveClick;
            CurrentView.BindModel(new ArticleViewModel());
        }

        private void SaveClick(object sender, EventArgs e)
        {
            var articleViewModel = CurrentView.GetArticle();

            _articleRepository.SaveOrUpdate(new Article { Name = articleViewModel.Name, Id = articleViewModel.Id });
            CurrentView.Close();
        }

        public override void Dispose()
        {
            CurrentView.CloseClick -= SaveClick;
        }
    }
}