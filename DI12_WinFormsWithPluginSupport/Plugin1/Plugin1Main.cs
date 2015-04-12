using System.Windows.Forms;
using PluginsBase;

namespace Plugin1
{
    public class Plugin1Main : IPlugin
    {
        public string Name
        {
            get { return "Test 1"; }
        }

        public void Run()
        {
            MessageBox.Show("Test 1");
        }
    }
}