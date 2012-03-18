using System;
using Core.DomainModels;
using Core.Repositories;
using SimpleMvp.Bases;

namespace SimpleMvp.Presenters
{
    public class CreateViewPresenter : Presenter<ICreateView>
    {
        private readonly ICreateView _view;
        private readonly IArticleRepository _articleRepository;

        public CreateViewPresenter(ICreateView view, IArticleRepository articleRepository)
            : base(view)
        {
            _view = view;
            _articleRepository = articleRepository;
            view.CloseClick += SaveClick;
        }

        private void SaveClick(object sender, EventArgs e)
        {
            var articleName = _view.GetArticleName();

            _articleRepository.SaveOrUpdate(new Article { Name = articleName });
            _view.Close();
        }

        public override void Dispose()
        {
            _view.CloseClick -= SaveClick;
        }
    }
}