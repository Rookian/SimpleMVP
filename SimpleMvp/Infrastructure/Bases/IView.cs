using System;
using System.Windows.Forms;

namespace SimpleMvp.Infrastructure.Bases
{
    public interface IView : IDisposable
    {
        event EventHandler CloseClick;
        void Close();
        DialogResult ShowDialog(IWin32Window parent);
    }
}