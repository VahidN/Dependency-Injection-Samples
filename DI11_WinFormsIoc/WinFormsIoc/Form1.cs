using System;
using System.Windows.Forms;
using WinFormsIoc.IoC;

namespace WinFormsIoc
{
    public partial class Form1 : Form
    {
        private readonly IFormFactory _formFactory;
        public Form1(IFormFactory formFactory)
        {
            _formFactory = formFactory;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnShowForm2_Click(object sender, EventArgs e)
        {
            var form2 = _formFactory.Create<Form2>();
            form2.Show();
        }
    }
}