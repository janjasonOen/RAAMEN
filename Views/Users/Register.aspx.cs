using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Project.Controller;
namespace Final_Project.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CreateAccBtn_Click(object sender, EventArgs e)
        {
            string gender = "";

            if(RadioButtonList1.SelectedValue != null)
            {
                gender = RadioButtonList1.SelectedValue;
            }

            string role = "";
            if(RadioButtonListRole.SelectedValue != null)
            {
                role = RadioButtonListRole.SelectedValue;
            }
           
            string resp = UserController.validateUser(role, TBName.Text, TBEmail.Text, gender, TBPw.Text, TBPwC.Text);

            ListBox1.Items.Clear();
            ListBox1.Items.Add(role);
            ListBox1.Items.Add(TBName.Text);
            ListBox1.Items.Add(TBEmail.Text);
            ListBox1.Items.Add(gender);
            ListBox1.Items.Add(TBPw.Text);
            ListBox1.Items.Add(TBPwC.Text);
            ListBox1.Items.Add(resp);
        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
        }
    }
}