<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMenu.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.ViewMenu"  MasterPageFile="~/UI/Page/dashboardmain.Master" MaintainScrollPositionOnPostback="true" %>
<%@ Register src="../../../UDC/SimpleServings/Menu/ViewMenu.ascx" tagname="ViewMenu" tagprefix="uc1" %>


<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
     <h1 class="titanictitle">Menu</h1>
        <asp:ScriptManager runat="server"></asp:ScriptManager>   
        <uc1:ViewMenu ID="ViewMenu1" runat="server" />
    </form>

</asp:Content>
