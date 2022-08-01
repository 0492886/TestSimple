<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditReport.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Reports.AddEditReport" MasterPageFile="~/UI/Page/dashboardmain.Master"%>

<%@ Register src="../../../UDC/SimpleServings/Reports/AddEditReport.ascx" tagname="AddEditReport" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">     
   
    <uc1:AddEditReport ID="AddEditReport1" runat="server" />
   
    </form>
    
</asp:Content>	