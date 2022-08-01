<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyStaff.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.MyStaff" %>
<%@ Register Src="StaffGrid.ascx" TagName="StaffGrid" TagPrefix="uc1" %>

 <div class="contentLeftPad">
    
        <span class="fatortitle">My Staff</span>
        
<uc1:StaffGrid ID="StaffGrid1" runat="server" />
</div>
