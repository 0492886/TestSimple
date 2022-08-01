<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModulePermissionsList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.UserGroup.ModulePermissionsList" %>
  <h2 class="title2">Module Security</h2>
<div class="dataList">
<asp:Repeater ID="rpModules" runat="server" OnItemDataBound="rpModules_ItemDataBound" >
    <HeaderTemplate>
        <div class="SectionTitle">            
          
        </div>
    </HeaderTemplate>
    
    <ItemTemplate>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* you must select a permission type" ControlToValidate="rbAssignedRole" />
            
            <div class="modperm">
            <asp:Label CssClass="modtitle" ID="lblModule" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CodeDescription")%>' />
            <asp:Label ID="lblModuleID"  Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CodeID")%>' />
            <asp:Label CssClass="hidden_msg" ID="lblMsg" runat="server" />
           
            <asp:RadioButtonList CssClass="rad_list" ID="rbAssignedRole" runat="server"/>
            <br />
            <hr class="wizard hide" />
        </div>
    </ItemTemplate>
</asp:Repeater>

</div>

<asp:Button CssClass="btn btn_save" ID="btnSave" runat="server" Text="Save Permissions" OnClick="btnSave_Click" />
     