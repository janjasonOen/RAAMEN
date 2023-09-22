using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Project.Controller;
using Final_Project.Model;

namespace Final_Project.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                HttpCookie uCook = Request.Cookies.Get("UserData");
                //Validator because this page is only accessible
                //to guests. If cookie exists, they are a member
                if (uCook != null)
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string password = TextBox2.Text;

            User x = UserController.userLogin(username, password);
            ListBox1.Items.Clear();
            if(x == null)
            {
                ListBox1.Items.Add("Wrong Username or Password!");
            }
            else
            {
                HttpCookie uCook = new HttpCookie("UserData");
                uCook["id"] = x.id.ToString();
                uCook["roleid"] = x.Roleid.ToString();
                uCook["email"] = x.Email;
                uCook["username"] = x.Username;
                uCook["gender"] = x.Gender;
                uCook["password"] = x.Password;
                Session["password"] = x.Password;
                
                if(Remember.Checked)
                {
                    uCook.Expires = DateTime.Now.AddHours(48);
                    Response.Cookies.Add(uCook);
                }
                //Cookie becomes a session cookie which will expire after session ends.
                //This is important because some features like profile uses cookies as its backbone for data.
                else
                {
                    Response.Cookies.Add(uCook);
                }
                Response.Redirect("Home.aspx");
            }

            

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}