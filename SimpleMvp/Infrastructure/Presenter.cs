using System.Windows.Forms;
using Core;
using Core.Common;
using SimpleMvp.Infrastructure.Bases;

namespace SimpleMvp.Infrastructure
{
    public abstract class Presenter<TView> : IPresenter<TView> where TView : class, IView
    {
        readonly TView _currentView;
        readonly IUnitOfWork _unitOfWork;

        protected Presenter(TView currentView, IUnitOfWork unitOfWork)
        {
            _currentView = currentView;
            _unitOfWork = unitOfWork;

            Ensure.That(currentView).IsNotNull();
            Ensure.That(unitOfWork).IsNotNull();
        }

        public TView CurrentView
        {
            get { return _currentView; }
        }

        public virtual void Dispose()
        {
            _unitOfWork.Dispose();
        }

        protected void ShowDialog(IView newForm, object parent)
        {
            newForm.ShowDialog((IWin32Window) parent);
        }
    }
}