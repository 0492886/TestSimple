<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLink.aspx.cs" MasterPageFile="../../caseManagementPages.Master" Title="Add Link"Inherits="SimpleServings.UI.Page.SimpleServings.Setting.AddLink" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/AddLink.ascx" TagName="AddLink" TagPrefix="uc1" %>



<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">
<span Class="fatortitle">Add Link</span>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <a class="linksright lnkCloseStyle"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>
        <uc1:AddLink ID="AddLink1" runat="server" />
</asp:Content>