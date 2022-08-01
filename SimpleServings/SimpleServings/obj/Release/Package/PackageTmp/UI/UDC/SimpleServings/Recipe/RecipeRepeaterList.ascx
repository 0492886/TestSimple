<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeRepeaterList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.RecipeRepeaterList" %>
<%@ Register src="RecipeRepeater.ascx" tagname="RecipeRepeater" tagprefix="uc1" %>
<asp:Label ID="lblMsg" CssClass="hidden_msg" runat="server" ForeColor="Red"></asp:Label>
    
<asp:Panel ID="pnPage" runat="server">
<asp:Panel ID="hidden" runat="server" Visible="false">  
    Filter By Recipe View: 
    <asp:DropDownList ID="ddlRecipeView" runat="server" AutoPostBack="true"
        onselectedindexchanged="ddlRecipeView_SelectedIndexChanged">
    </asp:DropDownList>
</asp:Panel>
    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="floatR mr20 btn_black"  onclick="btnSearch_Click" />
    <asp:TextBox ID="txtName" CssClass="searchInput" runat="server"></asp:TextBox>

    <uc1:RecipeRepeater ID="RecipeRepeater1" runat="server" />
</asp:Panel>

