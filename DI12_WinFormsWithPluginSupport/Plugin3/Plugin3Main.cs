using System.Windows.Forms;
using PluginsBase;

namespace Plugin3
{
    public class Plugin3Main : IPlugin
    {
        public string Name
        {
            get { return "Test 3"; }
        }

        public void Run()
        {
            MessageBox.Show("Test 3");
        }
    }
}