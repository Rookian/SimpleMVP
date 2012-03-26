namespace SimpleMvp.Infrastructure.Bases
{
    public interface IPresenterFactory<out TPresenter> where TPresenter : IPresenter<IView>
    {
        TPresenter Create(object ctorParameter);
        TPresenter Create();
    }
}