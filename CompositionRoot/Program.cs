using System;
using System.Windows.Forms;
using SimpleMvp.Bases;
using SimpleMvp.Infrastructure.Bases;
using StructureMap;

namespace CompositionRoot
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BootsTrapper.Boot();

            using (var mainForm = ObjectFactory.GetInstance<IPresenter<IMainView>>())
            {
                Application.Run((Form)mainForm.CurrentView);
            }
        }
    }
}