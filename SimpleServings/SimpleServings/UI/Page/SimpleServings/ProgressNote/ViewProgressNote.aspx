<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProgressNote.aspx.cs" MasterPageFile="../../caseManagementPages.Master" Title="View Case Note" Inherits="SimpleServings.UI.Page.SimpleServings.ProgressNote.ViewProgressNote" %>

<%@ Register Src="../../../UDC/SimpleServings/ProgressNote/ViewProgressNote.ascx" TagName="ViewProgressNote"
    TagPrefix="uc1" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">
    
    <span class="fatortitle">View Case Note</span>
   
    <%--<a class="linksright lnkCloseStyle"  href="JavaSCript: window.opener.location.reload(true);window.open('','_self','');self.close();">Close Window</a>--%>
    <a class="linksright lnkCloseStyle"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>
    <asp:Label ID="lblMailMsg" runat="server" Font-Bold="True" />
    
    <uc1:ViewProgressNote ID="ViewProgressNote1" runat="server" />
    
</asp:Content>