<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageStaff.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.ManageStaff" %>
<%@ Register Src="StaffSearchControl.ascx" TagName="StaffSearchControl" TagPrefix="uc1" %>


<asp:Label ID="lblMsg" CssClass="msglabel" runat="server"></asp:Label>
<asp:Panel  CssClass="contentBox manageStaff" ID="pnPage" runat="server" >

    <!--ManageStaff-->
     <div class="title2 h2Size">Manage Staff
            <a href="JavaScript:history.back();" class="back floatR">Back</a>
            <asp:HyperLink CssClass="add floatR" ID="HyperLink1" runat="server" 
                NavigateUrl="~/UI/Page/SimpleServings/Staff/StaffWizard.aspx" Target="_blank" Text="Add New Staff" >
            </asp:HyperLink>     
     </div>
      
    <div ID="divAddProvider" class="dataList" runat="server">
        <uc1:StaffSearchControl ID="StaffSearchControl1" runat="server" />
    </div>
    <div class="clearfix"></div>
</asp:Panel>
