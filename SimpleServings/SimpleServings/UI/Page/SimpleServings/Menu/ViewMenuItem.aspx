<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMenuItem.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.ViewMenuItem" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register src="../../../UDC/SimpleServings/Menu/ViewMenuItem.ascx" tagname="ViewMenuItem" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
    
        <uc1:ViewMenuItem ID="ViewMenuItem1" runat="server" />
    
    
    </form>
</asp:Content>