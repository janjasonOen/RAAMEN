using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Project.Model;
using Final_Project.Handler;

namespace Final_Project.Views.Transaction
{
    public partial class ViewTransactions : System.Web.UI.Page
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
            HttpCookie cookie = Request.Cookies.Get("UserData");
            List<Header> transactionList = new List<Header>();
            if (cookie == null)
            {
                Response.Redirect("~/Views/Users/Login.aspx");
            }
            //Not accessible to customer
            else if (cookie["roleid"] == "3")
            {
                Response.Redirect("~/Views/Users/Home.aspx");
            }
            navbarRole = cookie["roleid"];
            Repeater1.DataSource = TransactionHandler.getStaffHeader(0);
            Repeater2.DataSource = TransactionHandler.getStaffHeader(1);
            Repeater1.DataBind();
            Repeater2.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HttpCookie cookie = Request.Cookies.Get("UserData");
            if (e.CommandName == "Handle")
            {
                string res = TransactionHandler.updateHeaders(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(cookie["id"]));
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}