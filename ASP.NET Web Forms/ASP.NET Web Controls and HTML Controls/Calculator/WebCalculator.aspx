<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCalculator.aspx.cs" Inherits="Calculator.WebCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 376px;
            width: 525px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="LabelScreen" runat="server" Height="34px" Width="521px"></asp:Label>
        <asp:TextBox ID="TextBoxScreen" runat="server" BorderWidth="1px" Enabled="False" Font-Size="X-Large" Height="45px" Width="512px">
</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Font-Size="XX-Large" Font-Underline="True" Height="49px" OnClick="Button1_Click" Text="1" Width="122px" />
&nbsp;<asp:Button ID="Button2" runat="server" Font-Size="XX-Large" Height="49px" OnClick="Button2_Click" Text="2" Width="122px" />
&nbsp;<asp:Button ID="Button3" runat="server" Font-Size="XX-Large" Height="49px" OnClick="Button3_Click" Text="3" Width="122px" />
&nbsp;<asp:Button ID="ButtonPlus" runat="server" Font-Size="XX-Large" Height="49px" OnClick="ButtonPlus_Click" Text="+" Width="122px" />
        <br />
        <asp:Button ID="Button4" runat="server" Font-Size="XX-Large" Height="49px" OnClick="Button4_Click" Text="4" Width="122px" />
&nbsp;<asp:Button ID="Button5" runat="server" Font-Size="XX-Large" Height="49px" OnClick="Button5_Click" Text="5" Width="122px" />
&nbsp;<asp:Button ID="Button6" runat="server" Font-Size="XX-Large" Height="49px" OnClick="Button6_Click" Text="6" Width="122px" />
&nbsp;<asp:Button ID="ButtonMinus" runat="server" Font-Size="XX-Large" Height="49px" OnClick="ButtonMinus_Click" Text="-" Width="122px" />
        <br />
        <asp:Button ID="Button7" runat="server" Font-Size="XX-Large" Height="49px" OnClick="Button7_Click" Text="7" Width="122px" />
&nbsp;<asp:Button ID="Button8" runat="server" Font-Size="XX-Large" Height="49px" OnClick="Button8_Click" Text="8" Width="122px" />
&nbsp;<asp:Button ID="Button9" runat="server" Font-Size="XX-Large" Height="49px" OnClick="Button9_Click" Text="9" Width="122px" />
&nbsp;<asp:Button ID="ButtonMultiply" runat="server" Font-Size="XX-Large" Height="49px" OnClick="ButtonMultiply_Click" Text="X" Width="122px" />
        <br />
        <asp:Button ID="ButtonClear" runat="server" Font-Size="XX-Large" Height="49px" OnClick="ButtonClear_Click" Text="Clear" Width="122px" />
&nbsp;<asp:Button ID="Button0" runat="server" Font-Size="XX-Large" Height="49px" OnClick="Button0_Click" Text="0" Width="122px" />
&nbsp;<asp:Button ID="ButtonDivide" runat="server" Font-Size="XX-Large" Height="49px" OnClick="ButtonDivide_Click" Text="/" Width="122px" />
&nbsp;<asp:Button ID="ButtonSquareRoot" runat="server" Font-Size="XX-Large" Height="49px" OnClick="ButtonSquareRoot_Click" Text="√" Width="122px" />
        <br />
        <br />
        <asp:Button ID="ButtonEqual" runat="server" Font-Size="XX-Large" Height="37px" OnClick="ButtonEqual_Click" Text="=" Width="517px" />
    </form>
</body>
</html>
