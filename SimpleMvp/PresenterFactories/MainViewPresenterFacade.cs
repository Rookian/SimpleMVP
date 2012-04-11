using SimpleMvp.Bases;
using SimpleMvp.Infrastructure.Bases;

namespace SimpleMvp.PresenterFactories
{
    /// <summary>
    /// Aggregates all necessary presenters for the main view presenter
    /// </summary>
    public class MainViewPresenterFacade : IMainViewPresenterFacade
    {
        readonly IPresenterFactory<IPresenter<ICreateView>> _createPresenterFactory;
        readonly IPresenterFactory<IPresenter<IDetailView>> _detailPresenterFactory;

        public MainViewPresenterFacade(IPresenterFactory<IPresenter<ICreateView>> createPresenterFactory, IPresenterFactory<IPresenter<IDetailView>> detailPresenterFactory)
        {
            _createPresenterFactory = createPresenterFactory;
            _detailPresenterFactory = detailPresenterFactory;
        }

        public IPresenter<ICreateView> CreateCreatePresenter()
        {
            return _createPresenterFactory.Create();
        }

        public IPresenter<IDetailView> CreateDetailPresenter(object parameterCtor)
        {
            return _detailPresenterFactory.Create(parameterCtor);
        }
    }
}