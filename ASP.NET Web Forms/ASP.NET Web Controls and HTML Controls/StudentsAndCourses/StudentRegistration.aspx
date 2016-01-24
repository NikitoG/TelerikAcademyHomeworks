<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="StudentsAndCourses.StudentRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="LabelFirstName" runat="server" Text="First Name: "></asp:Label>
        <asp:TextBox ID="FirstName" runat="server" Text="Pesho"></asp:TextBox>
        <br />
        
        <asp:Label ID="LabelLastName" runat="server" Text="Last Name: "></asp:Label>
        <asp:TextBox ID="LastName" runat="server" Text="Peshov"></asp:TextBox>
        <br />
        
        <asp:Label ID="LabelFacultyNumber" runat="server" Text="Faculty Number:"></asp:Label>
        <asp:TextBox ID="FacultyNumber" runat="server" Text="111111"></asp:TextBox>
        <br />

        <asp:Label ID="LabelUniversity" runat="server" Text="Choose a university: "></asp:Label>
        <asp:DropDownList ID="University" runat="server">
            <asp:ListItem Value="UASG">UASG</asp:ListItem>
            <asp:ListItem Value="MIT">MIT</asp:ListItem>
            <asp:ListItem Value="TU">TU</asp:ListItem>
            <asp:ListItem Value="SU">SU</asp:ListItem>
        </asp:DropDownList>
        <br />

        <asp:Label ID="LabelSpecialty" runat="server" Text="Choose a specialty: "></asp:Label>
        <asp:DropDownList ID="Specialty" runat="server">
            <asp:ListItem Value="SSS">SSS</asp:ListItem>
            <asp:ListItem Value="IT">IT</asp:ListItem>
            <asp:ListItem Value="Driver">Driver</asp:ListItem>
            <asp:ListItem Value="Psycho">Psycho</asp:ListItem>
        </asp:DropDownList>
        <br />
        
        <asp:Label ID="LabelCourses" runat="server" Text="Choose a courses: "></asp:Label>
        <asp:ListBox ID="Courses" runat="server" SelectionMode="Multiple">
            <asp:ListItem Value="JS OOP">JS OOP</asp:ListItem>
            <asp:ListItem Value="C# intro">C# intro</asp:ListItem>
            <asp:ListItem Value="SPA">SPA</asp:ListItem>
            <asp:ListItem Value="ASP.NET">ASP.NET</asp:ListItem>
        </asp:ListBox>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />

        <asp:PlaceHolder ID="PlaceHolder" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
