<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffWizard.aspx.cs"   MasterPageFile="~/UI/Page/dashboardmain.Master"  Title="Add new staff" Inherits="SimpleServings.UI.Page.SimpleServings.Staff.StaffWizard" %>

<%@ Register Src="../../../UDC/SimpleServings/Staff/StaffWizard.ascx" TagName="StaffWizard"
    TagPrefix="uc1" %>



<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
<h1 class="titanictitle">Manage Staff</h1>
  <form id="form1" runat="server"> 

      <uc1:StaffWizard ID="StaffWizard1" runat="server">
        </uc1:StaffWizard>

</form>

</asp:Content>	