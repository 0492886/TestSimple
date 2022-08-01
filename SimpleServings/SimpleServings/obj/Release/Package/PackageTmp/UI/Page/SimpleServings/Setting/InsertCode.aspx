<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertCode.aspx.cs"  MasterPageFile="~/UI/Page/dashboardmain.Master" Title="Add Code" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.InsertCode" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/InsertCode.ascx" TagName="InsertCode"
    TagPrefix="uc1" %>


<asp:Content ID="ct1"  ContentPlaceHolderID="containerhome" runat="server">
<h1 class="titanictitle">Settings</h1>   
 <form id="form1" runat="server">   
        <uc1:InsertCode ID="InsertCode1" runat="server" />

 </form>
</asp:Content>
    	