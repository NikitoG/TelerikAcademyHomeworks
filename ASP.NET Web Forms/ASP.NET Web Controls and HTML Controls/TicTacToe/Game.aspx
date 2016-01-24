<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="TicTacToe.Game" EnableViewStateMac ="false" EnableSessionState="True" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode ="Never" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button00" runat="server" Text="-" OnClick="Button00_Click"/>
        <asp:Button ID="Button01" runat="server" Text="-" OnClick="Button01_Click"/>
        <asp:Button ID="Button02" runat="server" Text="-" OnClick="Button02_Click"/>
        <br />                                       
        <asp:Button ID="Button10" runat="server" Text="-" OnClick="Button10_Click"/>
        <asp:Button ID="Button11" runat="server" Text="-" OnClick="Button11_Click"/>
        <asp:Button ID="Button12" runat="server" Text="-" OnClick="Button12_Click"/>
        <br />                                       
        <asp:Button ID="Button20" runat="server" Text="-" OnClick="Button20_Click"/>
        <asp:Button ID="Button21" runat="server" Text="-" OnClick="Button21_Click"/>
        <asp:Button ID="Button22" runat="server" Text="-" OnClick="Button22_Click"/>
        <br />

        <asp:Label ID="result" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="NewGame" runat="server" Text="New Game" OnClick="NewGame_Click"/>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Win: "></asp:Label>
        <asp:Label ID="LabelWin" runat="server" Text="0"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="; Loss: "></asp:Label>
        <asp:Label ID="LabelLoss" runat="server" Text="0"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text=": Tie: "></asp:Label>
        <asp:Label ID="LabelTie" runat="server" Text="0"></asp:Label>
    </form>
</body>
</html>
