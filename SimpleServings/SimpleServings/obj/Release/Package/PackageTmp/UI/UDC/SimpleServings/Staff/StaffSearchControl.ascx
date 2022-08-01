<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffSearchControl.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.StaffSearchControl"  EnableViewState="true" %>
<%@ Register Src="StaffGrid.ascx" TagName="StaffGrid" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Panel ID="pnPage" runat="server">
    

    Filter By User Group:
    <asp:DropDownList ID="ddlUserGroup" runat="server" 
        AutoPostBack="True" OnSelectedIndexChanged="ddlUserGroup_SelectedIndexChanged">
    </asp:DropDownList>

    <asp:CheckBox ID="cbDeactiveStaff" runat="server"  
    SkinID="ChkBoxStyle" Text="&nbsp;Show Deactivated" 
    AutoPostBack="true"  OnCheckedChanged="btnFindByName_Click" />

    <asp:Button ID="btnFindByName" CssClass="floatR mr20 btn_black" runat="server" Text="Search"
        OnClick="btnFindByName_Click" EnableViewState="true" />
    <asp:TextBox  ID="txtName" CssClass="searchInput" runat="server" EnableViewState="true"></asp:TextBox>

    <br /><br />
    <asp:Label CssClass="labme" ID="lblMsg" Visible="false" runat="server" ></asp:Label>
    <uc1:StaffGrid ID="StaffGrid1" runat="server" />

<div class="clearfix"></div>
</asp:Panel>