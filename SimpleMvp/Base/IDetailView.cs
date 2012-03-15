using System.Windows.Forms;
using SimpleMvp.Model;

namespace SimpleMvp.Base
{
    public interface IDetailView : IView
    {
        void ShowDetails(ArticleViewModel model);
        DialogResult ShowDialog(IWin32Window parent);
    }
}