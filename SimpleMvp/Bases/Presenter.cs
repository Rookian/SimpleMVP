using System.Windows.Forms;

namespace SimpleMvp.Bases
{
    public abstract class Presenter<TView> : IPresenter<TView>
    {
        private readonly TView _view;

        protected Presenter(TView view)
        {
            _view = view;
        }

        public TView View
        {
            get { return _view; }
        }

        public abstract void Dispose();

        protected void ShowDialog(IView newForm, object parent)
        {
            newForm.ShowDialog((IWin32Window)parent);
        }
    }
}