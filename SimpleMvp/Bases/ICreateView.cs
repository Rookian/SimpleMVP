using SimpleMvp.Infrastructure.Bases;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Bases
{
    public interface ICreateView : IView
    {
        ArticleViewModel GetArticle();
        void BindModel(ArticleViewModel viewModel);
    }
}