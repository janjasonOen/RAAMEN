using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Project.Handler;

namespace Final_Project.Views
{
    public partial class UpdateRamen : System.Web.UI.Page
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
            string ramenId = "";
            if(!IsPostBack)
            {
                ramenId = Request.QueryString["ramenId"];
            }
            //Not accessible to customer
            HttpCookie cookie = Request.Cookies.Get("UserData");
            if (cookie == null)
            {
                Response.Redirect("~/Views/Users/Login.aspx");
            }
            else if(cookie["roleid"] == "3")
            {
                Response.Redirect("~/Views/Users/Home.aspx");
            }
            navbarRole = cookie["roleid"];
            List<RamenRes> ramenList = RamenHandler.GetRamen();

            for(int i = 0; i < ramenList.Count(); i++)
            {
                ListItem item = new ListItem(ramenList[i].id + "|" + ramenList[i].name);
                DropDownList1.Items.Add(item);
            }
            if(ramenId != null && ramenId.Length != 0)
            {
                for(int i = 0; i < DropDownList1.Items.Count; i++)
                {
                    if (ramenId == DropDownList1.Items[i].Value.Split('|')[0])
                    {
                        DropDownList1.SelectedIndex = i;
                        break;
                    }
                }
                
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList1.SelectedItem.Value.Split('|')[0]);
            int meatid = 0;
            if (RadioButtonList1.SelectedValue != null && RadioButtonList1.SelectedValue != "")
            {
                meatid = Convert.ToInt32(RadioButtonList1.SelectedValue);
            }
            string res = RamenHandler.UpdateRamen(id, meatid, TextBox1.Text, TextBox2.Text, TextBox3.Text);
            ListBox1.Items.Clear();
            ListBox1.Items.Add(res);
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRamen.aspx");
        }
    }
}