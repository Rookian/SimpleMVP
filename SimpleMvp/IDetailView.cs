using System;
using System.Windows.Forms;

namespace SimpleMvp
{
    public interface IView : IDisposable
    {
        event EventHandler CloseClick;
        void Close();
    }

    public interface IDetailView : IView
    {
        void ShowDetails(string model);
        DialogResult ShowDialog(IWin32Window parent);
    }
}