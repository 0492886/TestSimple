<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllRules.aspx.cs"  MasterPageFile="~/UI/Page/dashboardmain.Master"  Title="View All Rules" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.ViewAllRules" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/ViewAllRules.ascx" TagName="ViewAllRules"
    TagPrefix="uc1" %>



<asp:Content ID="ct1"  ContentPlaceHolderID="containerhome" runat="server">
  <h1 class="titanictitle">Settings</h1>
 <form id="form1" runat="server"> 
    <div class="ViewPageContainer curved"> <uc1:ViewAllRules ID="ViewAllRules1" runat="server" />
      </div>
</form>
</asp:Content>