<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMenuName.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.EditMenuName" MasterPageFile="~/UI/Page/dashboardmain.Master" %>



<%@ Register src="../../../UDC/SimpleServings/Menu/EditMenuName.ascx" tagname="EditMenuName" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
    
<h1 class="titanictitle">Menu</h1>
      
        <uc1:EditMenuName ID="EditMenuName1" runat="server" />
    
    
    </form>
</asp:Content>


