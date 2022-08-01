<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.RecipeList" %>
<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>
<%@ Register src="RecipeGrid.ascx" tagname="RecipeGrid" tagprefix="uc1" %>
<asp:Label ID="lblMsg" CssClass="hidden_msg" runat="server"></asp:Label>
  
<asp:Panel ID="pnPage" runat="server">

    <asp:Label CssClass="labme" ID="lblCount" runat="server"></asp:Label> 
    <div class="findOptions">   
    <asp:Panel ID="hidden" runat="server" Visible="false">     
    Filter By Recipe View:
    <asp:DropDownList ID="ddlRecipeView" runat="server" AutoPostBack="true"
        onselectedindexchanged="ddlRecipeView_SelectedIndexChanged">
    </asp:DropDownList>
    </asp:Panel>
    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="floatR btn_black" onclick="btnSearch_Click" />
    <asp:TextBox ID="txtName" CssClass="searchInput" runat="server" EnableViewState="true"></asp:TextBox>
           
     
        Filter By Tag :
        <asp:DropDownList ID="ddlRecipeTag" runat="server" AutoPostBack="true"
            onselectedindexchanged="ddlRecipeTag_SelectedIndexChanged"  >
        </asp:DropDownList>

                Filter By Status :
        <asp:DropDownList ID="ddlRecipeStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRecipeStatus_SelectedIndexChanged">
        </asp:DropDownList>


         <%--<div style="float: right">
      <ASPNetSpell:SpellTextBox ID="txtName" CssClass="searchInput" Height="16"  runat="server" EnableViewState="true" TextMode="SingleLine" ></ASPNetSpell:SpellTextBox>  &nbsp;  
         
             
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="floatR btn_black" onclick="btnSearch_Click" />
      </div>--%>
       
    <%--<asp:Panel ID="pnlDeactivate" runat="server" Visible="false">--%>
        <%--<asp:CheckBox ID="cbDeactiveRecipes" runat="server" Text ="&nbsp;Show Deactivated" AutoPostBack="true" OnCheckedChanged="cbDeactiveRecipes_CheckedChanged" Visible="false" />--%>
    <%--</asp:Panel>--%>
    </div>
    <div>
        <asp:CheckBox ID="cbDeactiveRecipes" runat="server" Text ="&nbsp;Show Deactivated" AutoPostBack="true" OnCheckedChanged="cbDeactiveRecipes_CheckedChanged" Visible="false" />
    </div>
    <uc1:RecipeGrid ID="RecipeGrid1" runat="server" />

<div class="clearfix"></div>
</asp:Panel>