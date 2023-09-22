using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Project.Model;
using Final_Project.Handler;

namespace Final_Project.Views
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies.Get("UserData");
            if (cookie == null)
            {
                Response.Redirect("~/Views/Users/Login.aspx");
            }
            else
            {
                Session.Abandon();
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                Response.Redirect("~/Views/Users/Homepage.aspx");   
            }
        }
        public string navbarRole { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            TBWelcome.Text = "";
            HttpCookie cookie = Request.Cookies.Get("UserData");
            if(cookie == null)
            {
                Response.Redirect("~/Views/Users/Login.aspx");
            }
            else
            {
                navbarRole = cookie["roleid"];
                TBWelcome.Text = Request.Cookies["UserData"]["username"] + ", Role: " + Request.Cookies["UserData"]["roleid"];
                List<User> memberList;
                switch (Convert.ToInt32(Request.Cookies["UserData"]["roleid"]))
                {
                    case 1:
                        TBMember.Visible = true;
                        TBStaff.Visible = true;
                        ListBoxStaff.Visible = true;
                        ListBoxMember.Visible = true;

                        memberList = UserHandler.getMember();
                        ListBoxMember.Items.Clear();
                        for (int i = 0; i < memberList.Count(); i++)
                        {
                            ListBoxMember.Items.Add("Name: " + memberList[i].Username + " Email: " + memberList[i].Email + " Gender: " + memberList[i].Gender);
                        }
                        memberList = UserHandler.getStaff();
                        ListBoxStaff.Items.Clear();
                        for(int i = 0; i < memberList.Count(); i++)
                        {
                            ListBoxStaff.Items.Add("Name: " + memberList[i].Username + " Email: " + memberList[i].Email + " Gender: " + memberList[i].Gender);
                        }
                        break;

                    case 2:
                        TBMember.Visible = true;
                        ListBoxMember.Visible = true;
                        
                        memberList = UserHandler.getMember();
                        ListBoxMember.Items.Clear();
                        for(int i = 0; i < memberList.Count(); i++)
                        {
                            ListBoxMember.Items.Add("Name: " + memberList[i].Username + " Email: " + memberList[i].Email + " Gender: " + memberList[i].Gender);
                        }
                        break;
                    case 3:
                        
                        break;

                    default:
                        break;
                }
               
                
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}