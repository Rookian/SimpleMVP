namespace SimpleMvp
{
    public interface IPresenterFactory
    {
        TPresenter Create<TPresenter>(ConstructorParameter constructorParameterArgument) where TPresenter : IPresenter<IView>;

        void ShowDialog(IDetailView newForm, object parent);
    }
}