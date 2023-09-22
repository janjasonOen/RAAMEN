using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Project.Handler;


namespace Final_Project.Views.Ramen
{
    public partial class ManageRamen : System.Web.UI.Page
    {
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies.Get("UserData");
            if (cookie == null)
            {
                Response.Redirect("~/Views//Users/Login.aspx");
            }
            else
            {
                Session.Abandon();
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
Response.Redirect("~/Views/Users/Homepage.aspx");   
            }
        }
        public string navbarRole
        {
            get; set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Not accessible to customer
            HttpCookie cookie = Request.Cookies.Get("UserData");
            if (cookie == null)
            {
                Response.Redirect("~/Views/Users/Login.aspx");
            }
            else if (cookie["roleid"] == "3")
            {
                Response.Redirect("~/Views/Users/Home.aspx");
            }
            navbarRole = cookie["roleid"];
            List<RamenRes> ramenList = RamenHandler.GetRamen();
            Repeater1.DataSource = ramenList;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string ramenId = e.CommandArgument.ToString();
            if (e.CommandName == "Update")
            {
                
                Response.Redirect("UpdateRamen.aspx?ramenId=" + ramenId);
            }
            else if(e.CommandName == "Delete")
            {
                RamenHandler.DeleteRamen(Convert.ToInt32(ramenId));
                //refresh
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateRamen.aspx");
        }
    }
}