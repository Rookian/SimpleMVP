namespace SimpleMvp
{
    interface IViewFactory
    {
        TView Create<TView>(ConstructorParameter constructorParameterArgument);
        void ShowDialog(IView newForm, object parent);
    }
}