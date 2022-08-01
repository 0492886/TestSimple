<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignUserGroup.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.AssignUserGroup" %>
<%@ Register Src="ViewModulePermissions.ascx" TagName="ViewModulePermissions" TagPrefix="uc3" %>
<%@ Register Src="ModulePermissionsList.ascx" TagName="ModulePermissionsList" TagPrefix="uc4" %>

<table>
    <tr>
        <td>Select User Group</td>
        <td><asp:DropDownList ID="ddUserGroup" runat="server" AutoPostBack="true"/></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddUserGroup"
                ErrorMessage="* required" InitialValue="1"></asp:RequiredFieldValidator></td>
    </tr>
</table>
<br />    
Selected Group Permissions:
<uc3:ViewModulePermissions ID="GroupPermissions" runat="server" ShowEditCols="false"></uc3:ViewModulePermissions>

<br />
Set Individual Staff Permissions:
<br />
<uc4:ModulePermissionsList ID="AddStaffPermissions" runat="server" ShowSaveButton="false"></uc4:ModulePermissionsList>

