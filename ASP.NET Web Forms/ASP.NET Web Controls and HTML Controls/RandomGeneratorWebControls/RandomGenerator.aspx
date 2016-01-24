<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="RandomGeneratorWebControls.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="ErrorMessage" runat="server" Text=""></asp:Label>
        <br />
        <asp:TextBox ID="MinValue" placeholder="Min Value" runat="server"></asp:TextBox>
        <asp:TextBox ID="MaxValue" placeholder="Max Value" runat="server"></asp:TextBox>
        <asp:Button ID="GetRandom" runat="server" Text="Get Random Number" OnClick="GetRandom_Click"/>
        <asp:Label ID="Result" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
