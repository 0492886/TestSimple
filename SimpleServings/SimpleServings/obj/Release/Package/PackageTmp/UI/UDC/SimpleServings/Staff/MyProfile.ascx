<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.MyProfile" %>
<%@ Register Src="ViewModulePermissions.ascx" TagName="ViewModulePermissions" TagPrefix="uc4" %>

<%@ Register Src="ViewComments.ascx" TagName="ViewComments" TagPrefix="uc3" %>
<%@ Register Src="ViewGeneralInfo.ascx" TagName="ViewGeneralInfo" TagPrefix="uc1" %>
<%@ Register Src="ViewAccountInfo.ascx" TagName="ViewAccountInfo" TagPrefix="uc2" %>
	

<div class="contentLeftPad">    
       <span class="title2 h2Size">Manage Staff</span>
		<a href="JavaScript:history.back();" class= "back btn_floatR">Back</a>
    <div class="ViewPageContainer">
        <div class="section">
            <div class="SectionTitle">
                <span>General Info</span>
                <asp:HyperLink CssClass="btn_edit btn_floatR" ID="hlEditGeneralInfo" runat="server"  Text="Edit general info" />
            </div>
            <uc1:ViewGeneralInfo ID="ViewGeneralInfo1" runat="server" />
        </div>
       
        <div class="SectionBarTitle">Account Information :</div>
        <div class="section">
            <asp:HyperLink CssClass="lnkEditStyle linksright" ID="hlEditAccountInfo" runat="server"  Text="Edit Account Info" />
            <uc2:ViewAccountInfo ID="ViewAccountInfo1" runat="server" />
        </div>
        
        <div class="SectionBarTitle">Module Permissions :</div>
        <div class="section">
            <uc4:ViewModulePermissions ID="ViewModulePermissions1" runat="server" ShowEditCols="false" />
        </div>
        
                       
       <div class="section">
            <div class="SectionTitle">
                <span>Comments :</span>
                <asp:HyperLink CssClass="btn_add btn_floatR" ID="hlAddComments" runat="server"  Text="Add Comments" />
                <uc3:ViewComments ID="ViewComments1" runat="server" />
            </div>
        </div>
        <asp:Label ID="lblStaffID" runat="server" Visible="False" />
        
    </div>
</div>