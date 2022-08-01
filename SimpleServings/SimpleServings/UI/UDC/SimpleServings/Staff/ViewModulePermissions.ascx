<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewModulePermissions.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.ViewModulePermissions" %>
<!-- <div class="SectionBarTitle">Module Permissions</div> -->
<div class="dataLabel"><span class="wtitleSmall">UserGroup:</span><asp:Label CssClass="dataInput" ID="lblUserGroup" runat="server"></asp:Label></div>
<%--
<div class="gridViewWrapper">
    <asp:GridView CssClass="DatagridStyle" GridLines="None" ID="gvPermissions" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvPermissions_RowDataBound" OnRowCreated="gvPermissions_RowCreated" >
        <AlternatingRowStyle CssClass="DatagridStyleAltRow" />
        <Columns>
            <asp:BoundField  DataField="CodeID" FooterText="ModuleID" />
            <asp:BoundField DataField="CodeDescription" HeaderText="Module Name" />
            <asp:BoundField HeaderText="Permission In Effect" >
                <ItemStyle Font-Bold="True" ForeColor="#3f8939" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Staff Permission" />
            <asp:BoundField HeaderText="Group Permission" />
            <asp:HyperLinkField HeaderText="Edit Staff Permissions" Text="Edit" />
            <asp:HyperLinkField HeaderText="Edit Group Permissions" Text="Edit" />
        </Columns>
    </asp:GridView>
</div>
--%>


<div class="gridViewWrapper dgContainer">
    <asp:GridView CssClass="DatagridStyle" GridLines="None" ID="gvPermissions1" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvPermissions_RowDataBound" OnRowCreated="gvPermissions_RowCreated" >
        <AlternatingRowStyle CssClass="DatagridStyleAltRow" />
        <Columns>
            <asp:BoundField  DataField="CodeID" FooterText="ModuleID" />
            <asp:BoundField DataField="CodeDescription" HeaderText="Module Name" />
                   
            <asp:BoundField HeaderText="Group Permission" />
            
            <asp:HyperLinkField HeaderText="Edit Group Permissions" Text="Edit" />
        </Columns>
    </asp:GridView>
</div>

