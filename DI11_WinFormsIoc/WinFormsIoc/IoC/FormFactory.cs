using System.Windows.Forms;

namespace WinFormsIoc.IoC
{
    public class FormFactory : IFormFactory
    {
        public T Create<T>() where T : Form
        {
            return SmObjectFactory.Container.GetInstance<T>();
        }
    }
}