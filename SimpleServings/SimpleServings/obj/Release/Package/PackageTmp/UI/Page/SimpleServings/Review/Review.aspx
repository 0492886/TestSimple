<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../../caseManagementPages.Master" Title="View Review" CodeBehind="Review.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Review.Review" %>

<%@ Register Src="../../../UDC/SimpleServings/Review/Review.ascx" TagName="Review" TagPrefix="uc1" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <span class="fatortitle"> View Review </span>
    <a class="linksright lnkCloseStyle" href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>
    <asp:Label ID="lblMailMsg" runat="server" Font-Bold="True" /><br />
    <uc1:Review ID="Review1" runat="server" />
 
</asp:Content>
