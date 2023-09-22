using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Final_Project.Handler;

namespace Final_Project.Views.Ramen
{
    public partial class OrderRamen : System.Web.UI.Page
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
            //accessible to customer & admin only
            HttpCookie cookie = Request.Cookies.Get("UserData");
            if (cookie == null)
            {
                Response.Redirect("~/Views/Users/Login.aspx");
            }
            else if (cookie["roleid"] == "2")
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
            string cart = e.CommandArgument.ToString();
            if (e.CommandName == "Order")
            {
                ListBox1.Items.Add(cart);
            }
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
        }

        protected void BuyButton_Click(object sender, EventArgs e)
        {
            //Gets ramen ids and quantities
            Dictionary<int, int> ramenQuantities = new Dictionary<int, int>();
            for (int i = 0; i < ListBox1.Items.Count; i++)
            {
                string[] dataCart = ListBox1.Items[i].Text.Split('|');

                int id = Convert.ToInt32(dataCart[0]);
                if (ramenQuantities.ContainsKey(id))
                {
                    // Increment quantity if the ramen ID already exists in the dictionary
                    ramenQuantities[id]++;
                }
                else
                {
                    // Add the ramen ID to the dictionary with a quantity of 1
                    ramenQuantities[id] = 1;
                }
            }
            //Gets customer ID
            HttpCookie cookie = Request.Cookies.Get("UserData");
            if (cookie == null)
            {
                Response.Redirect("~/Views/Users/Login.aspx");
            }
            string response = TransactionHandler.createTransaction(Convert.ToInt32(cookie["id"]), ramenQuantities);
        }
    }
}