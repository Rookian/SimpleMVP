namespace SimpleMvp.Bases
{
    public interface IPresenterFactoryForMainViewPresenter
    {
        IPresenter<ICreateView> CreateCreatePresenter();
        IPresenter<IDetailView> CreateDetailPresenter(object parameterCtor);
    }
}