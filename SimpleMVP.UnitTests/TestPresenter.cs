using Core;
using SimpleMvp.Infrastructure;
using SimpleMvp.Infrastructure.Bases;

namespace SimpleMVP.UnitTests
{
    class TestPresenter : Presenter<IView> { public TestPresenter(IView currentView, IUnitOfWork unitOfWork) : base(currentView, unitOfWork) { } }
}