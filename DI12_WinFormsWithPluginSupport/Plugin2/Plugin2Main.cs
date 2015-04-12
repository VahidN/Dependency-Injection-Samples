using System.Windows.Forms;
using PluginsBase;

namespace Plugin2
{
    public class Plugin2Main : IPlugin
    {
        public string Name
        {
            get { return "Test 2"; }
        }

        public void Run()
        {
            MessageBox.Show("Test 2");
        }
    }
}