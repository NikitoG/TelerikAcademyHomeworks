<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserControl.aspx.cs" Inherits="ASP.NET_Caching_Data.UserControl" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Register Src="~/MyCacheableControl.ascx" TagPrefix="my" TagName="CacheableControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <my:CacheableControl runat="server"/>
    </div>
    <div class="jumbotron">
        <h3>Time: <%= DateTime.Now.ToString(CultureInfo.InvariantCulture) %></h3>
    </div>
</asp:Content>
