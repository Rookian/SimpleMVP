using System;
using System.Collections.Generic;
using Core;

namespace SimpleMvp.Base
{
    public interface IMainView : IView
    {
        void BindModel(IEnumerable<Article> articles);
        event EventHandler DetailsClick;
        Article GetSelectedArticle();
    }
}