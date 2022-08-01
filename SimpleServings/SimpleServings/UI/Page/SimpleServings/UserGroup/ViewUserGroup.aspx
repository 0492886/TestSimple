<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUserGroup.aspx.cs" MasterPageFile="../../caseManagementPages.Master" Title="View User Group" Inherits="SimpleServings.UI.Page.SimpleServings.UserGroup.ViewUserGroup" %>

<%@ Register Src="../../../UDC/SimpleServings/UserGroup/ViewUserGroup.ascx" TagName="ViewUserGroup"
    TagPrefix="uc1" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">
    
    <span class="fatortitle">View User Group</span>
   
    <a class="linksright lnkCloseStyle"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>
    
    
        <uc1:ViewUserGroup ID="ViewUserGroup1" runat="server" />
    
</asp:Content>

    
   