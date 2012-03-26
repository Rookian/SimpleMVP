using SimpleMvp.Infrastructure.Bases;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Bases
{
    public interface IDetailView : IView
    {
        void ShowDetails(ArticleViewModel model);
    }
}