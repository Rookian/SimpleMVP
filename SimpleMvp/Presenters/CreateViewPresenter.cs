using System;
using Core.DomainModels;
using Core.Repositories;
using SimpleMvp.Bases;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Presenters
{
    public class CreateViewPresenter : Presenter<ICreateView>
    {
        private readonly IArticleRepository _articleRepository;

        public CreateViewPresenter(ICreateView view, IArticleRepository articleRepository)
            : base(view)
        {
            _articleRepository = articleRepository;
            View.CloseClick += SaveClick;
            View.BindModel(new ArticleViewModel());
        }

        private void SaveClick(object sender, EventArgs e)
        {
            var articleViewModel = View.GetArticle();

            _articleRepository.SaveOrUpdate(new Article { Name = articleViewModel.Name, Id = articleViewModel.Id });
            View.Close();
        }

        public override void Dispose()
        {
            View.CloseClick -= SaveClick;
        }
    }
}