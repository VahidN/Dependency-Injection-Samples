using System.IO;
using System.Windows.Forms;
using PluginsBase;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace WinFormsWithPluginSupport.Core
{
    public class PluginsRegistry : Registry
    {
        public PluginsRegistry()
        {
            this.Scan(scanner =>
            {
                scanner.AssembliesFromPath(
                    path: Path.Combine(Application.StartupPath, "plugins"),
                    // يك اسمبلي نبايد دوبار بارگذاري شود
                    assemblyFilter: assembly =>
                    {
                        return !assembly.FullName.Equals(typeof(IPlugin).Assembly.FullName);
                    });
                scanner.AddAllTypesOf<IPlugin>().NameBy(item => item.FullName);
            });
        }
    }
}