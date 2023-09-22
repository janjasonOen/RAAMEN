<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRamen.aspx.cs" EnableEventValidation="false" Inherits="Final_Project.Views.Ramen.ManageRamen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                <li><asp:Button ID="Button2" runat="server" Text="Logout" OnClick="logoutButton_Click" /></li>
            </ul>
        </div>
            Manage Ramen<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Insert Ramen" OnClick="Button1_Click" />
            <br />
        </div>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <h3><%#Eval("Name") %></h3>
                <p>Broth: <%# Eval("Broth") %></p>
                <p>Price: <%# Eval("Price") %></p>
                <p>Meat: <%# Eval("meatName") %></p>
                <asp:Button ID="UpdateButton" runat="server" UseSubmitBehavior="false" CommandName="Update" CommandArgument='<%# Eval("id") %>' Text="Update" />
                <asp:Button ID="DeleteButton" runat="server" UseSubmitBehavior="false" CommandName="Delete" CommandArgument='<%# Eval("id") %>' Text="Delete" />
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
