using SimpleMvp.Infrastructure.Bases;

namespace SimpleMvp.Bases
{
    public interface IMainViewPresenterFacade
    {
        IPresenter<ICreateView> CreateCreatePresenter();
        IPresenter<IDetailView> CreateDetailPresenter(object viewModel);
    }
}