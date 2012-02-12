using System;
using System.Collections.Generic;
using Core;

namespace SimpleMvp
{
    public interface IMainView : IView
    {
        void ShowArticles(IEnumerable<Article> articles);
        event EventHandler DetailsClick;
        string GetSelectedArticle();
    }
}