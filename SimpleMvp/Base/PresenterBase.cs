namespace SimpleMvp.Base
{
    public class PresenterBase : IPresenter
    {
        private readonly IView _view;

        public PresenterBase(IView view)
        {
            _view = view;
        }

        public void Dispose()
        {
            _view.Dispose();   
        }
    }
}