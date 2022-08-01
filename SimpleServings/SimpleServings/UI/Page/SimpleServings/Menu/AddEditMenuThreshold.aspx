<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditMenuThreshold.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.AddEditMenuThreshold" MasterPageFile="~/UI/Page/dashboardmain.Master"  %>

<%@ Register src="../../../UDC/SimpleServings/Menu/AddEditMenuThreshold.ascx" tagname="AddEditMenuThreshold" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
    
<h1 class="titanictitle">&nbsp;</h1>
                
    <uc1:AddEditMenuThreshold ID="AddEditMenuThreshold1" runat="server" />            
    
    </form>
</asp:Content>
