<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Final_Project.Views.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <ul>
                <%-- Admin Links --%> 
                <% if (navbarRole == "1")
                    { %>
                <li><a href="../Ramen/ManageRamen.aspx">Manage Ramen</a></li>
                <li><a href="../Transaction/ViewTransactions.aspx">Order Queue</a></li>
                <li><a href="../Transaction/History.aspx">History</a></li>
                <li><a href="../Transaction/ShowReport.aspx">Show Report</a></li>
                <% } %>

                <%-- Staff Links --%> 
                <% if (navbarRole == "2")
                    { %>
                <li><a href="Home.aspx">Home</a></li>
                <li><a href="../Ramen/ManageRamen.aspx">ManageRamen</a></li>
                <li><a href="../Transaction/ViewTransactions.aspx">Order Queue</a></li>
                <% } %>

                <%-- Member Links --%>
                 <% if (navbarRole == "3")
                    { %>
                <li><a href="../Ramen/OrderRamen.aspx">Order Ramen</a></li>
                <li><a href="../Transaction/History.aspx">History</a></li>
                <% } %>

                <%-- Common Links --%> 
                <li><a href="../Users/UpdateProfile.aspx">Profile</a></li>
                <li><asp:Button ID="Button1" runat="server" Text="Logout" OnClick="logoutButton_Click" /></li>
            </ul>
        </div>
        
        <div>
            <p>Welcome back,</p>
            <p>
                <asp:TextBox ID="TBWelcome" runat="server" Width="211px"></asp:TextBox>
            </p>
            <p>
                &nbsp;
            </p>
            <p>
                <asp:TextBox ID="TBMember" runat="server" Text="Members" Visible="false" ReadOnly="true" Width="60px">Members</asp:TextBox>
            </p>
        </div>
        <asp:ListBox ID="ListBoxMember" runat="server" Height="94px" Width="611px" Visible="false"></asp:ListBox>
        <p>
            <asp:TextBox ID="TBStaff" runat="server" Text="Staff" Visible="false" ReadOnly="true" Width="60px">Staff</asp:TextBox>
        </p>
        <asp:ListBox ID="ListBoxStaff" runat="server" Height="94px" Width="611px" Visible="false"></asp:ListBox>
    </form>
</body>
</html>
