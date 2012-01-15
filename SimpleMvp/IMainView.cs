using System;
using System.Collections.Generic;

namespace SimpleMvp
{
    public interface IMainView : IView
    {
        void ShowArticles(IEnumerable<string> articles);
        event EventHandler DetailsClick;
        string GetSelectedArticle();
    }
}