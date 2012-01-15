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
            ObjectFactory.Initialize(x =>
            {
                x.Scan(s =>
                {
                    s.TheCallingAssembly();
                    s.WithDefaultConventions();
                    s.ConnectImplementationsToTypesClosing(typeof(IPresenter<>));
                });

                x
                    .For<Func<Type, ConstructorParameter, IPresenter<IView>>>()
                    .Use((type, param) => (IPresenter<IView>)ObjectFactory
                                                                  .With(param.ParameterName)
                                                                  .EqualTo(param.ParameterValue)
                                                                  .GetInstance(type));
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var mainForm = ObjectFactory.GetInstance<IPresenter<IMainView>>())
            {
                Application.Run((Form)mainForm.View);
            }
        }
    }
}
