<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderRamen.aspx.cs" Inherits="Final_Project.Views.Ramen.OrderRamen" %>

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
                <li><asp:Button ID="Button1" runat="server" Text="Logout" OnClick="logoutButton_Click" /></li>
            </ul>
        </div>
            Order Ramen<br />
            <asp:ListBox ID="ListBox1" runat="server" Width="451px"></asp:ListBox>
            <br />
            <asp:Button ID="ClearButton" runat="server" Text="ClearCart" OnClick="ClearButton_Click"/>
            <asp:Button ID="BuyButton" runat="server" Text="Buy Cart" OnClick="BuyButton_Click" />
            <br />
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <h3><%#Eval("Name") %></h3>
                <p>Broth: <%# Eval("Broth") %></p>
                <p>Price: <%# Eval("Price") %></p>
                <p>Meat: <%# Eval("meatName") %></p>
                <asp:Button ID="OrderButton" runat="server" UseSubmitBehavior="false" CommandName="Order" CommandArgument='<%# Eval("id") + "|" + Eval("Name") + "|" + Eval("Broth") + "|" + Eval("Price") + "|" + Eval("meatName") %>' Text="Order Ramen" />
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </form>
</body>
</html>
