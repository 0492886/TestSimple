<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeFavoriteList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.RecipeFavoriteList" %>
<%@ Register src="RecipeGrid.ascx" tagname="RecipeGrid" tagprefix="uc1" %>

<asp:Label ID="lblMsg" CssClass="hidden_msg" runat="server"></asp:Label>
<asp:Panel ID="pnPage" runat="server">
    <uc1:RecipeGrid ID="RecipeGrid1" runat="server" />
</asp:Panel>
