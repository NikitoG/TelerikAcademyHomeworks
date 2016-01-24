<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="Escaping.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBoxInput" runat="server" Text="<script>alert('Hack!')</script>"></asp:TextBox>
        <asp:Button ID="Button" runat="server" Text="Button" OnClick="Button_Click"/>
        <br />

        <asp:Label ID="LabelForTextBox" runat="server" Text="Text box control:"></asp:Label>
        <asp:TextBox ID="TextBoxOutput" runat="server" ></asp:TextBox>
        <br />

        <asp:Label ID="LabelForLabel" runat="server" Text="Label control:"></asp:Label>
        <asp:Label ID="LabelOutput" runat="server" Mode="Encode" ></asp:Label>
    </form>
</body>
</html>
