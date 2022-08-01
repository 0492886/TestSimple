<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRule.aspx.cs"  MasterPageFile="~/UI/Page/dashboardmain.Master" Title="Add Rule" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.AddRule" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/AddRule.ascx" TagName="AddRule" TagPrefix="uc1" %>



<asp:Content ID="ct1"  ContentPlaceHolderID="containerhome" runat="server">
<h1 class="titanictitle">Settings</h1>
 <form id="form1" runat="server">
   <uc1:AddRule ID="AddRule1" runat="server" />
 </form>

</asp:Content>