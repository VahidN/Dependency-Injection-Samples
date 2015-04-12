using System.Linq;
using System.Windows.Forms;
using PluginsBase;
using StructureMap;
using WinFormsWithPluginSupport.Core;

namespace WinFormsWithPluginSupport
{
    public partial class FrmMain : Form
    {
        private readonly IContainer _container;

        public FrmMain(IContainer container)
        {
            _container = container;
            InitializeComponent();
        }

        private void BtnRun_Click(object sender, System.EventArgs e)
        {
            var plugins = _container.GetAllInstances<IPlugin>().ToList();
            foreach (var plugin in plugins)
            {
                plugin.Run();
            }
        }

        private void BtnReload_Click(object sender, System.EventArgs e)
        {
            _container.EjectAllInstancesOf<IPlugin>();
            _container.Configure(x =>
                x.AddRegistry<PluginsRegistry>()
            );
        }
    }
}