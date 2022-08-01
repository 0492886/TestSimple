<%@ Page Language="C#" AutoEventWireup="true" Title="Menu Status Change" CodeBehind="MenuStatusChangeSubmission.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.MenuStatusChangeSubmission" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register src="../../../UDC/SimpleServings/Menu/MenuStatusChangeSubmission.ascx" tagname="MenuStatusChangeSubmission" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">

<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
<h1 class="titanictitle">Actions Available</h1>
   
    <a class="linksright lnkCloseStyle hide"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>        
     <uc1:MenuStatusChangeSubmission ID="MenuStatusChangeSubmission1" runat="server" />
</form>
</asp:Content>	