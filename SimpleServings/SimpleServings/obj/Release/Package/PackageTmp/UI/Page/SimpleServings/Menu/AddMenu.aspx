<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenu.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.AddMenu" MasterPageFile="~/UI/Page/dashboardmain.Master" MaintainScrollPositionOnPostback="true" %>

<%@ Register src="../../../UDC/SimpleServings/Menu/AddMenu.ascx" tagname="AddMenu" tagprefix="uc1" %>



<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
    
<h1 class="titanictitle">Menu</h1>
      
        <uc1:AddMenu ID="AddMenu1" runat="server" />
    
    
    </form>
</asp:Content>
