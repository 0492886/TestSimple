<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuThresholdByMealType.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.MenuThresholdByMealType" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register src="../../../UDC/SimpleServings/Menu/MenuThresholdByMealType.ascx" tagname="MenuThresholdByMealType" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
    
<h1 class="titanictitle">Menu Threshold</h1>
      

    <uc1:MenuThresholdByMealType ID="MenuThresholdByMealType1" runat="server" />

    
    </form>
</asp:Content>
