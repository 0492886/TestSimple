<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewReport.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Reports.ViewReport" MasterPageFile="~/UI/Page/dashboardmain.Master"  %>

<%@ Register src="../../../UDC/SimpleServings/Reports/ViewReport.ascx" tagname="ViewReport" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">     
    <uc1:ViewReport ID="uc1" runat="server" />
    </form>
    
</asp:Content>	