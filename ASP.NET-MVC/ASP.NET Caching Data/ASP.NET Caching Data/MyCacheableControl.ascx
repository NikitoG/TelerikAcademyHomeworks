<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyCacheableControl.ascx.cs" Inherits="ASP.NET_Caching_Data.MyCacheableControl" %>
<%@ OutputCache Duration="120" VaryByParam="none" Shared="true" %>
<%@ Import Namespace="System.Globalization" %>

<div class="jumbotron">
    <h3>User control</h3>
    <h3>Time: <%= DateTime.Now.ToString(CultureInfo.InvariantCulture) %></h3>
</div>