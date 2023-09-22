using Final_Project.Handler;
using Final_Project.Model;
using Final_Project.Report;
using System;
using System.Collections.Generic;
using System.Web;

namespace Final_Project.Views
{
    public partial class ShowReport : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;

            DataSet1 data = loadData(TransactionHandler.getHeader(0));
            report.SetDataSource(data);
        }

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
            if (cookie == null)
            {
                Response.Redirect("~/Views/Users/Login.aspx");
            }
            else if (cookie["roleid"] != "1")
            {
                Response.Redirect("~/Views/Users/Home.aspx");
            }
            navbarRole = cookie["roleid"];
        }

        public DataSet1 loadData(List<Header> headerList)
        {
            DataSet1 newData = new DataSet1();
            var headerTable = newData.Header;
            var detailTable = newData.Detail;
            int grandtotal = 0;
            int subtotal = 0;

            foreach (Header x in headerList)
            {
                var newHeaderRow = headerTable.NewRow();
                newHeaderRow["id"] = x.id;
                newHeaderRow["Customerid"] = x.Customerid;
                newHeaderRow["staffid"] = x.staffid;
                newHeaderRow["Date"] = x.Date;
                headerTable.Rows.Add(newHeaderRow);
                subtotal = 0;
                grandtotal = 0;

                foreach (Detail y in x.Details)
                {
                    Model.Ramen ramen = RamenHandler.GetSingleRamen(y.Ramenid);
                    var newDetailRow = detailTable.NewRow();
                    newDetailRow["Ramen Name"] = ramen.Name;
                    newDetailRow["Headerid"] = y.Headerid;
                    newDetailRow["Ramenid"] = y.Ramenid;
                    newDetailRow["Quantity"] = y.Quantity;
                    newDetailRow["Price"] = ramen.Price;
                    subtotal = Convert.ToInt32(ramen.Price) * y.Quantity;
                    newDetailRow["Subtotal"] = subtotal;
                    grandtotal += subtotal;
                    detailTable.Rows.Add(newDetailRow);
                }
                newHeaderRow["Total"] = grandtotal;

            }

            return newData;
        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }
    }
}