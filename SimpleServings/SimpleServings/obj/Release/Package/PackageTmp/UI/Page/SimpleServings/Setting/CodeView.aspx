<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodeView.aspx.cs" MasterPageFile="../../caseManagementPages.Master" Title="View Code" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.CodeView" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/CodeView.ascx" TagName="CodeView" TagPrefix="uc1" %>


        
        <asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">
    
    <span class="fatortitle"> View Code </span>  
    <a class="linksright lnkCloseStyle"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>
    
    
<uc1:CodeView ID="CodeView1" runat="server" />   
</asp:Content>

   
