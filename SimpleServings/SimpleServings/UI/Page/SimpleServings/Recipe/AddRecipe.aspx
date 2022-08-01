<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRecipe.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Recipe.AddRecipe"  MasterPageFile="~/UI/Page/dashboardmain.Master" MaintainScrollPositionOnPostback="true"  %>
<%@ Register src="../../../UDC/SimpleServings/Recipe/AddRecipe.ascx" tagname="AddRecipe" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
        <h1 class="titanictitle">Add Recipe</h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <uc1:AddRecipe ID="AddRecipe1" runat="server" />
    </form>
</asp:Content>	

