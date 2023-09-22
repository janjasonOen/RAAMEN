<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Final_Project.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <h1>Welcome to Raamen</h1>
        </div>
        <asp:Button ID="LoginBtn" runat="server" OnClick="LoginBtnClick" Text="Login" />
        <p>
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtnClick" />
        </p>
    </form>
</body>
</html>
