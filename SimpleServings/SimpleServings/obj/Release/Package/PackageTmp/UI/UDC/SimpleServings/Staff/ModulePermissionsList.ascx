<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModulePermissionsList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.ModulePermissionsList" %>

<div class="section">
<asp:Repeater ID="rpModules" runat="server" OnItemDataBound="rpModules_ItemDataBound" >

    <HeaderTemplate>
     
    </HeaderTemplate>

<ItemTemplate>
 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* you must select a permission type" ControlToValidate="rbAssignedRole" />

        <div class="modperm">
        <h2 class="title2 h2hack"><asp:Label ID="lblModule" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CodeDescription")%>' /></h2>
        
        <asp:Label ID="lblModuleID"  Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CodeID")%>' />
        
        <asp:Label  ID="lblMsg" runat="server" />

        

        <asp:RadioButtonList CssClass="rad_list" ID="rbAssignedRole" runat="server" />
        
        <br />
        
     </div>
       

</ItemTemplate>

</asp:Repeater>

</div>

<asp:Button ID="btnSave" runat="server" Text="Save Permissions" CssClass="btn btn_save" OnClick="btnSave_Click" />
<asp:Label ID="lblStaffID" runat="server" Visible="False"></asp:Label>


