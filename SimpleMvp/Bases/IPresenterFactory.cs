namespace SimpleMvp.Bases
{
    public interface IPresenterFactory
    {
        TPresenter Create<TPresenter>(object ctorParameter) where TPresenter : IPresenter<IView>;
        TPresenter Create<TPresenter>();
    }
}