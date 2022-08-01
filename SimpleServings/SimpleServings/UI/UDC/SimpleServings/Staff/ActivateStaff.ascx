<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivateStaff.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.ActivateStaff" %>
<%@ Register Src="ViewGeneralInfo.ascx" TagName="ViewGeneralInfo" TagPrefix="uc2" %>



<div class="contentLeftPad">
<h2 class="fatortitle">Activate Staff</h2>
<asp:Label ID="lblMsg" runat="server" />
 <div  class="ViewPageContainer curved" >
<asp:Panel ID="pnPage" runat="server">
<asp:Label ID="lblStaffID" runat="server" Visible="false" />
 <div class="SectionBarTitle curvedTop">General Info</div>
  <div class="section">
<uc2:ViewGeneralInfo ID="ViewGeneralInfo1" runat="server" />
</div>

<div class="section">

Are you sure you want to Activate this staff member?
&nbsp;<asp:Button ID="btnActivate" runat="server" Text="Yes" CssClass="btnStyle" OnClick="btnActivate_Click" />
&nbsp;<asp:Button ID="Cancel" runat="server" Text="No"  CssClass="btnStyle" OnClick="Cancel_Click" />
<br /><br /></div>
</asp:Panel>
</div>
</div>