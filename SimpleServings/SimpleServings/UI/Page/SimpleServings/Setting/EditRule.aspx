<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRule.aspx.cs"  MasterPageFile="~/UI/Page/dashboardmain.Master" Title="Edit Rule" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.EditRule" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/EditRule.ascx" TagName="EditRule" TagPrefix="uc1" %>



<asp:Content ID="ct1"  ContentPlaceHolderID="containerhome" runat="server">
   <h1 class="titanictitle">Settings</h1>
 <form id="form1" runat="server">   
        <uc1:EditRule ID="EditRule1" runat="server" />
 </form>
</asp:Content>