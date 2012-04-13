using System.Linq;
using System.Reflection;
using SimpleMvp.Bases;
using SimpleMvp.Infrastructure.Bases;
using SimpleMvp.ViewModels;
using SimpleMvp.Views;

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

        public IPresenter<IDetailView> CreateDetailPresenter(object viewModel)
        {
            var presenter = _detailPresenterFactory.Create(viewModel);
            var genericTypeDefinition = presenter.CurrentView.GetType().BaseType.GetGenericTypeDefinition();
            var propertyInfo = genericTypeDefinition.GetProperties().FirstOrDefault(x => x.Name == "Model");
            propertyInfo.SetValue(presenter.CurrentView, viewModel,null);
            return _detailPresenterFactory.Create(viewModel);
        }
    }
}