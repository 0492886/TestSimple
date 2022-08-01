<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignRules.aspx.cs" MasterPageFile="../../caseManagementPages.Master" Title="Assign Rule" Inherits="SimpleServings.UI.Page.SimpleServings.CaseClient.AssignRules" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/AssignRules.ascx" TagName="AssignRules"
    TagPrefix="uc2" %>



<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <a class="linksright lnkCloseStyle"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>
       <uc2:AssignRules ID="AssignRules1" runat="server" />
</asp:Content>