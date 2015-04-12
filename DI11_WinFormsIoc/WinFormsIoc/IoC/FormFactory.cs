using System.Windows.Forms;
using StructureMap;

namespace WinFormsIoc.IoC
{
    public class FormFactory : IFormFactory
    {
        public T Create<T>() where T : Form
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
}