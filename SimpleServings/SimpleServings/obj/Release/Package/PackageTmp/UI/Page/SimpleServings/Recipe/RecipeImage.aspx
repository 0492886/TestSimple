<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipeImage.aspx.cs" MasterPageFile="~/UI/Page/dashboardmain.Master" Inherits="SimpleServings.UI.Page.SimpleServings.Recipe.RecipeImage" %>

<%@ Register src="../../../UDC/SimpleServings/Recipe/RecipeImage.ascx" tagname="RecipeImage" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
        <h1 class="titanictitle">Recipe Image</h1>  
          
        <uc1:RecipeImage ID="RecipeImage1" runat="server" />
       <asp:Button ID="btnSelect" runat="server" Text="Select" onclick="btnSelect_Click" />
    </form>
</asp:Content>	
