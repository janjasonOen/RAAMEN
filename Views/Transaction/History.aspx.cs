using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Project.Handler;
using Final_Project.Model;

namespace Final_Project.Views.Transaction
{
    public partial class History : System.Web.UI.Page
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
            //User is customer
            else if (cookie["roleid"] == "3")
            {
                transactionList = TransactionHandler.getHeader(Convert.ToInt32(cookie["id"]));
            }
            //User is admin
            else if (cookie["roleid"] == "1")
            {
                //Sending 0 equates to get all headers
                transactionList = TransactionHandler.getHeader(0);
            }
            navbarRole = cookie["roleid"];
            Repeater1.DataSource = transactionList;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string headerid = e.CommandArgument.ToString();
            if(e.CommandName == "Details")
            {
                Response.Redirect("TransactionDetails.aspx?headerId=" + headerid);
            }
        }
    }
}