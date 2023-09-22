<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTransactions.aspx.cs" Inherits="Final_Project.Views.Transaction.ViewTransactions" %>

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
            View Transactions<br />
            <br />
            Unhandled
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <h3><%#Eval("id") %></h3>
                    <p>
                        Staff ID: <%# Eval("staffid") %>
                    </p>
                    <p>
                        Customer ID: <%# Eval("Customerid") %>
                    </p>
                    <p>
                        Date: <%# Eval("Date") %>
                    </p>
                    <asp:Button ID="HandleButton" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Handle" Text="Handle" UseSubmitBehavior="false" />
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </form>
    <p>
        Handled</p>
     <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <h3><%#Eval("id") %></h3>
                    <p>
                        Staff ID: <%# Eval("staffid") %>
                    </p>
                    <p>
                        Customer ID: <%# Eval("Customerid") %>
                    </p>
                    <p>
                        Date: <%# Eval("Date") %>
                    </p>
            </ItemTemplate>
        </asp:Repeater>
    <p>
        &nbsp;</p>
</body>
</html>
