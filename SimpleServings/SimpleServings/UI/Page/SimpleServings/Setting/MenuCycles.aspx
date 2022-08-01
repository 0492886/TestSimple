<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Page/dashboardmain.Master" AutoEventWireup="true" CodeBehind="MenuCycles.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.MenuCycles" %>
<%@ Register src="../../../UDC/SimpleServings/Setting/ViewCycle.ascx" tagname="ViewCycle" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="containerhome" runat="server">
    <form id="form1" runat="server">
    <uc1:ViewCycle ID="ViewCycle1" runat="server" />
    </form>
</asp:Content>
