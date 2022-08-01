<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeactivateStaff.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.DeactivateStaff" %>
<%@ Register Src="ViewGeneralInfo.ascx" TagName="ViewGeneralInfo" TagPrefix="uc2" %>



<div class="contentBox">
<div class="title2 h2Size">Deactivate Staff
<a class="back floatR" href="JavaScript:history.back();">Back</a></div>
<asp:Label ID="lblMsg" runat="server" />
 <div class="dataList" >
<asp:Panel ID="pnPage" runat="server">
<asp:Label ID="lblStaffID" runat="server" Visible="false" />
 <div class="SectionBarTitle curvedTop hide">General Info</div>
  <div class="section">
<uc2:ViewGeneralInfo ID="ViewGeneralInfo1" runat="server" />
</div>

<div class="dataRow">

Are you sure you want to deactivate this staff member?
&nbsp;<asp:Button ID="btnDeactivate" runat="server" Text="Yes" CssClass="btn" OnClick="btnDeactivate_Click" />
&nbsp;<asp:Button ID="Cancel" runat="server" Text="No"  CssClass="btn" OnClick="Cancel_Click" />
<br /><br /></div>
</asp:Panel>
</div>
</div>

   <div class="clearfix"></div>  