<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sums.aspx.cs" Inherits="WebFormsSumator.Sums" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
            + 
        <asp:TextBox ID="TextBoxSecondNumber" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonCalculateSum" runat="server" Text="=" OnClick="ButtonCalculateSum_Click" />
            <asp:TextBox ID="TextBoxResult" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
