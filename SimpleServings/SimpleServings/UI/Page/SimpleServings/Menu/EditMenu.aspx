<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMenu.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.EditMenu" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register src="../../../UDC/SimpleServings/Menu/EditMenu.ascx" tagname="EditMenu" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
    
<h1 class="titanictitle">Menu</h1>
      
        <uc1:EditMenu ID="EditMenu1" runat="server" />
    
    
    </form>
</asp:Content>

