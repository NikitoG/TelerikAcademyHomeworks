<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAllFiles.aspx.cs" Inherits="ASP.NET_Caching_Data.ListAllFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1><%= Page.Title %></h1>
    <div class="jumbotron">
        <h2>Value taken from cache: <span id="currentTimeSpan" runat="server"></span></h2>
    </div>
    <div class="jumbotron">
        <h2>File path: <span id="filePathSpan" runat="server"></span></h2>
    </div>
</asp:Content>
