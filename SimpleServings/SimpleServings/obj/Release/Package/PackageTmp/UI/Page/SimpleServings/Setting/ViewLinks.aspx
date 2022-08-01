<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewLinks.aspx.cs" MasterPageFile="../../caseManagementPages.Master" Title="View Links" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.ViewLinks" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/ViewLinks.ascx" TagName="ViewLinks"
    TagPrefix="uc1" %>


<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <a class="linksright lnkCloseStyle"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>
    <uc1:ViewLinks ID="ViewLinks1" runat="server" />
        
        
</asp:Content>