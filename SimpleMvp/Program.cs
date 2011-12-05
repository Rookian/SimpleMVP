using System;
using System.Windows.Forms;
using StructureMap;

namespace SimpleMvp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ObjectFactory.ResetDefaults();
            ObjectFactory.Initialize(x =>
            {
                x.For<IArticleRepository>().Use<ArticleRepository>();
                x.For<IViewFactory>().Use<ViewFactory>();
                x.For<IMainFormView>().Use<MainForm>();
                x.For<IDetailView>().Use<DetailForm>();
                x.For<IPresenter<IMainFormView>>().Use<MainFormPresenter>();
                x.For<IPresenter<IDetailView>>().Use<DetailFormPresenter>();
                x.For<Func<Type, ConstructorParameter, IPresenter<IView>>>().
                    Use((type, param) => 
                        (IPresenter<IView>) ObjectFactory.With(param.ParameterName).EqualTo(param.ParameterValue).GetInstance(type));
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = ObjectFactory.GetInstance<IPresenter<IMainFormView>>();
            Application.Run((Form)mainForm.View);
        }
    }
}
