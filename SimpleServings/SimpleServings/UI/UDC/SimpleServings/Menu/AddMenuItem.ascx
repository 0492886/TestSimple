<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddMenuItem.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.AddMenuItem" %>

<%@ Register src="../Recipe/RecipeSearchList.ascx" tagname="RecipeSearchList" tagprefix="uc1" %>

<asp:Label ID="lblMsg" runat="server"></asp:Label>

<asp:Panel  CssClass="contentBox" ID="pnPage" runat="server">
<div class="dataList">
    <asp:Label ID="lblMenuID" runat="server" Visible="false"></asp:Label>
    Program Type                   
    <asp:Label ID="lblContract" runat="server"></asp:Label>
    <br />
    Week in Cycle
    <asp:DropDownList ID="ddlWeek" runat="server"></asp:DropDownList>
    <br />
    Day                                
    <asp:DropDownList ID="ddlDays" runat="server"></asp:DropDownList>
    <br />
             
    Type
    <asp:DropDownList ID="ddlMenuItemType" runat="server"></asp:DropDownList>
    <br />
    <br />
    <uc1:RecipeSearchList ID="RecipeSearchList1" runat="server" />
    <br />
  </div>                               
    <asp:Button ID="btnAddMenuItem" CssClass="btn btn_save" runat="server" Text="Save" onclick="btnAddMenuItem_Click" />
</asp:Panel>
 