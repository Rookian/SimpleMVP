using System;
using System.Collections.Generic;
using SimpleMvp.Infrastructure.Bases;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Bases
{
    public interface IMainView : IView
    {
        void BindModel(IEnumerable<ArticleViewModel> articles);
        event EventHandler DetailsClick;
        ArticleViewModel GetSelectedArticle();
        event EventHandler CreateClick;
        event EventHandler DeleteClick;
    }
}