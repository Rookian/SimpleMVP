using System;
using System.Collections.Generic;

namespace SimpleMvp
{
  public interface IMainFormView
  {
    void ShowArticles(IEnumerable<string> articles);
    event EventHandler DetailsClick;
    event EventHandler CloseClick;
    string GetSelectedArticle();
    void Close();
  }
}