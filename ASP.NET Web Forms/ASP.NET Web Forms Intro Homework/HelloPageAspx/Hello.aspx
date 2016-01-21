<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="HelloPageAspx.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonName" runat="server" Text="Say Hello!" OnClick="ButtonName_Click"/>
        <asp:Label ID="LabelSayHello" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
