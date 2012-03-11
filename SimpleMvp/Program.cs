using System;
using System.Windows.Forms;
using Infrastructure;
using NHibernate;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var buildSessionFactory = new ConfigurationFactory().Build().BuildSessionFactory();

            ObjectFactory.Initialize(x =>
            {
                x.Scan(s =>
                {
                    s.AssembliesFromApplicationBaseDirectory();
                    s.WithDefaultConventions();
                    s.ConnectImplementationsToTypesClosing(typeof(IPresenter<>));
                });
                x.For<ISession>().Use(buildSessionFactory.OpenSession);                
                x.For<Func<Type, object, IPresenter<IView>>>().Use((type, param) => (IPresenter<IView>)ObjectFactory
                                                                  .With(param.GetType(), param)
                                                                  .GetInstance(type));
            });

            using (var mainForm = ObjectFactory.GetInstance<IPresenter<IMainView>>())
            {
                Application.Run((Form)mainForm.View);
            }
        }
    }
}
