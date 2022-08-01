<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCode.aspx.cs" MasterPageFile="~/UI/Page/dashboardmain.Master" Title="Edit Code" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.EditCode" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/EditCode.ascx" TagName="EditCode" TagPrefix="uc1" %>



<asp:Content ID="ct1"  ContentPlaceHolderID="containerhome" runat="server"> 
<h1 class="titanictitle">Settings</h1>
 <form id="form1" runat="server">
  <uc1:EditCode ID="EditCode1" runat="server" />
        </form>

</asp:Content>