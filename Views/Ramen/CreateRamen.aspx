<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateRamen.aspx.cs" Inherits="Final_Project.Views.CreateRamen" %>

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
                <li><asp:Button ID="Button3" runat="server" Text="Logout" OnClick="logoutButton_Click" /></li>
            </ul>
        </div>
        <div>
            Create a Ramen<br />
            Meat Type:</div>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Value="1">Chicken</asp:ListItem>
            <asp:ListItem Value="2">Beef</asp:ListItem>
            <asp:ListItem Value="3">Pork</asp:ListItem>
        </asp:RadioButtonList>
        <p>
            Name (Must have &quot;Ramen&quot;):</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Width="173px"></asp:TextBox>
        </p>
        <p>
            Broth:</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Width="166px"></asp:TextBox>
        </p>
        <p>
            Price (&gt;= 3000):</p>
        <p>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create Ramen" />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back to manage ramen" />
    </form>
</body>
</html>
