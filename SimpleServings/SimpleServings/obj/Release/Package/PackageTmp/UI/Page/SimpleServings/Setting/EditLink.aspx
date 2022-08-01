<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditLink.aspx.cs" MasterPageFile="../../caseManagementPages.Master" Title="Edit Link" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.EditLink" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/EditLink.ascx" TagName="EditLink" TagPrefix="uc1" %>



<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <a class="linksright lnkCloseStyle hide"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>
        <uc1:EditLink ID="EditLink1" runat="server" />
</asp:Content>