<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserGroupList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.UserGroup.UserGroupList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="AddUserGroup.ascx" TagName="AddUserGroup" TagPrefix="uc1" %>



<asp:Label ID="lblMsg" runat="server" />

<asp:Panel ID="pnPage" CssClass="contentBox" runat="server">
  <div class="title2 h2Size">                       
User Group
   <asp:LinkButton CssClass="add floatR" ID="lnkAdd" runat="server" Visible='<%#CanAdd() %>' OnClick="lnkAdd_Click" CausesValidation="False" >Add New User Group</asp:LinkButton> 
  </div>
    <div id="divAddAddress" class="" runat="server">
        <div class="gridViewWrapper dataList">
        <div class="dgContainer">
            <asp:GridView CssClass="DatagridStyle table table-hover" GridLines="None"  PageSize="40" ID="gvUserGroups" runat="server" AutoGenerateColumns="False" OnRowCommand="gvUserGroups_RowCommand" >
                <AlternatingRowStyle CssClass="DatagridStyleAltRow" />
                <PagerStyle  CssClass="DatagridStylePgRow" />
                <Columns>
                    <asp:BoundField DataField="UserGroupID" HeaderText="Group ID" Visible="false" />
                    <asp:BoundField DataField="UserGroupName" HeaderText="Group Name" />
                    <asp:BoundField DataField="AccessLevelText" HeaderText="Access Level" />
                    <asp:BoundField DataField="CreatedOn" HeaderText="Added On" />
                    <asp:BoundField DataField="CreatedByText" HeaderText="Created By" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" CommandArgument='<%# Eval("UserGroupID") %>' Text="Edit" runat="server" OnCommand="lnkEdit_Command" Visible='<%#CanEdit() %>' CausesValidation="false"/>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBtnRemove" runat="server" CommandName="Remove"  CommandArgument='<%# Eval("UserGroupID") %>' Visible='<%#CanDelete() %>'>Remove</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBtnUserList" runat="server" CommandName="UserList" CommandArgument='<%# Eval("UserGroupID") %>'>UserList</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                 </Columns>
            </asp:GridView>
        </div>
        </div>
    </div>

<div class="clearfix"></div>   
</asp:Panel>