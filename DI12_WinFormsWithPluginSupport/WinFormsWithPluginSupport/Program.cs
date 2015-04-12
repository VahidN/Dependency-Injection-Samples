using System;
using System.Windows.Forms;
using WinFormsWithPluginSupport.Core;

namespace WinFormsWithPluginSupport
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(IocConfig.Container.GetInstance<FrmMain>());
        }
    }
}