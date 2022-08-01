<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Reports.reports" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register src="../../../UDC/SimpleServings/Reports/ReportList.ascx" tagname="ReportList" tagprefix="uc2" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">     
    <uc2:ReportList ID="ReportList1" runat="server" />
    </form>
    
</asp:Content>	
