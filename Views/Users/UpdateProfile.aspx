<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="Final_Project.Views.UpdateProfile" %>

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
                <li><asp:Button ID="Button2" runat="server" Text="Logout" OnClick="logoutButton_Click" /></li>
            </ul>
        </div>
        <div>
            Welcome to Update Profile<br />
            Username(5-15 Characters):</div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        Email(Must end with &quot;.com&quot;):<br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        Gender(Male/Female):<br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        Password:<br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        Confirm Password:<br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Update Profile" OnClick="Button1_Click" />
        </p>
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    </form>
</body>
</html>
