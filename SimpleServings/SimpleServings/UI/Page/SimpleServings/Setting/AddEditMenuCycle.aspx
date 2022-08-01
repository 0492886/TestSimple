<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Page/dashboardmain.Master" AutoEventWireup="true" CodeBehind="AddEditMenuCycle.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.AddEditMenuCycle" %>
<%@ Register src="../../../UDC/SimpleServings/Setting/AddEditCycle.ascx" tagname="AddEditCycle" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="containerhome" runat="server">
<h1 class="titanictitle">Settings</h1>
    <form id="form1" runat="server">
    <uc1:AddEditCycle ID="AddEditCycle1" runat="server" />
    </form>

</asp:Content>
