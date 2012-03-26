using System.Windows.Forms;
using Infrastructure.Nhibernate;

namespace SimpleMvp.Bases
{
    public abstract class Presenter<TView> : IPresenter<TView>
    {
        private readonly TView _currentView;
        readonly IUnitOfWork _unitOfWork;

        protected Presenter(TView currentView, IUnitOfWork unitOfWork)
        {
            _currentView = currentView;
            _unitOfWork = unitOfWork;
        }

        public TView CurrentView
        {
            get { return _currentView; }
        }

        public virtual void Dispose()
        {
            _unitOfWork.Dispose();
        }

        protected  void ShowDialog(IView newForm, object parent)
        {
            newForm.ShowDialog((IWin32Window)parent);
        }
    }
}