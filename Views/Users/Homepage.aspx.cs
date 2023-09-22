using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views//Users/Login.aspx");
        }

        protected void RegisterBtnClick(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}