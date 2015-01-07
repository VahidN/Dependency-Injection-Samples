using System;
using DI05.Services;

namespace DI05
{
    public partial class UserControl1 : System.Web.UI.UserControl
    {
        public IUsersService UsersService { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblEmail2.Text = string.Format("From UserControl1: {0}", UsersService.GetUserEmail(1));
        }
    }
}