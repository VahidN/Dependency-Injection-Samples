using System;
using System.Windows.Forms;
using WinFormsIoc.IoC;

namespace WinFormsIoc
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

            Application.Run(IoCConfig.Resolve<Form1>());
        }
    }
}
