<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReplicateMenu.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.ReplicateMenu" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register src="../../../UDC/SimpleServings/Menu/ReplicateMenu.ascx" tagname="ReplicateMenu" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
  
<h1 class="titanictitle">Replicate Menu</h1>
      
        <uc1:ReplicateMenu ID="ReplicateMenu1" runat="server" />
    
    
    </form>
</asp:Content>
