<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModulePermissions.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.ModulePermissions" %>
<%@ Register Src="ViewModulePermissions.ascx" TagName="ViewModulePermissions" TagPrefix="uc2" %>
<%@ Register Src="ModulePermissionsList.ascx" TagName="ModulePermissionsList" TagPrefix="uc1" %>

<div class="contentBox marginTopFix">
<div class="title2 h2Size">Module Permissions  
<a class="back floatR" href="JavaScript:history.back();">Back</a>   
 </div>
  <div ID="divAddProvider" class="dataList" runat="server">
   <div class="dataRow">
   <div class="dataInput">
   <table class="filtersList">
                    <tbody>
                    <tr>
                        <td class="dataLabel">Assign staff to the following user group: &nbsp; <asp:DropDownList Width="350px" ID="ddUserGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddUserGroup_SelectedIndexChanged">
</asp:DropDownList></td> 
                    </tr>
                    
                    <tr>
                    <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddUserGroup"
    ErrorMessage="* you must select a user group" InitialValue="0"></asp:RequiredFieldValidator><br/>
<span class="warnNote"> &nbsp; If staff should have more permissions than selected user group, please assign them below:</span>
                    </td>
                    </tr>
                    
                    </tbody>
</table>
    


</div>
</div>
<uc1:ModulePermissionsList ID="ModulePermissionsList1" runat="server" />
<%--

<asp:Button CssClass="btn_floatR ActivityEdit" ID="btnPreview" runat="server" Text="Refresh Matrix" OnClick="btnPreview_Click" />
<br />

<div class="section">
<div class="SectionTitle"><span>Permissions Matrix</span></div>
<span class="warnNote">If User Group and Staff Permissions have a conflict, the higher permission will be given:
</span>
--%>
<div class="section">
<h2 class="title2 h2hack">Permissions</h2>
<div class="dataInput bold"><span></span></div>
<uc2:ViewModulePermissions ID="ViewModulePermissions1" runat="server" ShowEditCols="false" />
</div>
<%--
    <asp:Button ID="BtnSave" CssClass="btn btn_save"  runat="server" Text="Save Permissions" OnClick="BtnSave_Click" Visible="False" />

--%>
</div>
</div>