using System.Windows.Forms;
using Core;

namespace SimpleMvp.Base
{
    public interface IDetailView : IView
    {
        void ShowDetails(Article model);
        DialogResult ShowDialog(IWin32Window parent);
    }
}