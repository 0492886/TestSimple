<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRecipe.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Recipe.EditRecipe" MasterPageFile="~/UI/Page/dashboardmain.Master" MaintainScrollPositionOnPostback="true"%>
<%@ Register src="../../../UDC/SimpleServings/Recipe/EditRecipe.ascx" tagname="EditRecipe" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
        <h1 class="titanictitle">Edit Recipe</h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />    
        <uc1:EditRecipe ID="EditRecipe1" runat="server" />
    </form>
</asp:Content>	