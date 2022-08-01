<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.MenuList" MasterPageFile="~/UI/Page/dashboardmain.Master" %>
<%@ Register src="../../../UDC/SimpleServings/Menu/MenuList.ascx" tagname="MenuList" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h1 class="titanictitle">Menu</h1>
        <uc1:MenuList ID="MenuList1" runat="server" />
    </form>
</asp:Content>
    