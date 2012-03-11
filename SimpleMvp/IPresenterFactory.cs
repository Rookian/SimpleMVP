namespace SimpleMvp
{
    public interface IPresenterFactory
    {
        TPresenter Create<TPresenter>(object parameter)
            where TPresenter : IPresenter<IView>;

        void ShowDialog(IDetailView newForm, object parent);
    }
}