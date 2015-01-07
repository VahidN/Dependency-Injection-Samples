using System;
using DI05.Services;

namespace DI05
{
    public partial class Default : System.Web.UI.Page
    {
        public IUsersService UsersService { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblEmail1.Text = string.Format("From Default Page: {0}", UsersService.GetUserEmail(1));
        }
    }
}