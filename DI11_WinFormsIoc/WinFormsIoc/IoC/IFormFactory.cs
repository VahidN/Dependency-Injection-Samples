using System.Windows.Forms;

namespace WinFormsIoc.IoC
{
    public interface IFormFactory
    {
        T Create<T>() where T : Form;
    }
}