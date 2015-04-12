using System;
using System.Windows.Forms;
using WinFormsIoc.IoC;
using WinFormsIoc.Services;

namespace WinFormsIoc
{
    public partial class Form2 : Form
    {
        private readonly IEmailsService _emailsService;
        private readonly IFormFactory _formFactory;
        public Form2(IEmailsService emailsService, IFormFactory formFactory)
        {
            _emailsService = emailsService;
            _formFactory = formFactory;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            _emailsService.SendEmail("user1@site.com", "user2@site2.com", "test", "Hello!");
        }

        private void btnShowForm3_Click(object sender, EventArgs e)
        {
            var frm3 = _formFactory.Create<Form3>();
            frm3.Show();
        }
    }
}