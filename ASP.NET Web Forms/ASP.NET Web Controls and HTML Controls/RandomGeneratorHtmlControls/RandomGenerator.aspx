<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGenerator.aspx.cs" Inherits="RandomGeneratorHtmlControls.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <p id="ErrorMessage" runat="server"></p>
        <input id="MinVaLue" type="number" runat="server" placeholder="Min Value"/>
        <input id="MaxValue" type="number" runat="server" placeholder="Max Value"/>
        <input id="ButtonSubmit" type="button"
                runat="server" value="Get Random Number"
                onserverclick="ButtonSubmit_ServerClick" />
        <input id="RandomNumber" type="text" runat="server" placeholder="Random Number" disabled="disabled"/>
    </form>
</body>
</html>
