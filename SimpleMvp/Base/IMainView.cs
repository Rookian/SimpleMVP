using System;
using System.Collections.Generic;
using SimpleMvp.Model;

namespace SimpleMvp.Base
{
    public interface IMainView : IView
    {
        void BindModel(IEnumerable<ArticleViewModel> articles);
        event EventHandler DetailsClick;
        ArticleViewModel GetSelectedArticle();
    }
}