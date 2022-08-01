<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditModulePermissions.aspx.cs"   MasterPageFile="~/UI/Page/dashboardmain.Master" Inherits="SimpleServings.UI.Page.SimpleServings.Staff.EditModulePermissions" %>

<%@ Register Src="../../../UDC/SimpleServings/Staff/ModulePermissions.ascx" TagName="ModulePermissions"
    TagPrefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form ID="form1" runat="server">
    <h1 class="titanictitle">Edit General Information</h1>
        <uc1:ModulePermissions ID="ModulePermissions1" runat="server" />
    
   
    </form>
   </asp:Content>	
