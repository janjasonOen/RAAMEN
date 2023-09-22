using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Project.Controller;

namespace Final_Project.Views
{
    public partial class CreateRamen : System.Web.UI.Page
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
            navbarRole = cookie["roleid"];
            if (cookie == null)
            {
                Response.Redirect("~/Views/Users/Login.aspx");
            }
            //Not accessible to customer
            else if(cookie["roleid"] == "3")
            {
                Response.Redirect("~/Views/Users/Home.aspx");
            }
            navbarRole = cookie["roleid"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int meatid = 0;
            if(RadioButtonList1.SelectedValue != null && RadioButtonList1.SelectedValue != "")
            {
                meatid = Convert.ToInt32(RadioButtonList1.SelectedValue);
            }

            string res = RamenController.CreateRamen(meatid, TextBox1.Text, TextBox2.Text, TextBox3.Text);
            ListBox1.Items.Clear();
            ListBox1.Items.Add(meatid.ToString());
            ListBox1.Items.Add(TextBox1.Text);
            ListBox1.Items.Add(TextBox2.Text);
            ListBox1.Items.Add(TextBox3.Text);
            ListBox1.Items.Add(res);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRamen.aspx");
        }
    }
}