<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Final_Project.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter Username:</div>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        </p>
        <p>
            Enter Password:</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:CheckBox ID="Remember" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Remember Me" />
        </p>
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Width="129px"></asp:ListBox>
    </form>
</body>
</html>
