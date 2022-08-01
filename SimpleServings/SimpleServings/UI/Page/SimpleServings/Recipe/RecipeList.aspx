<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipeList.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Recipe.RecipeList"  MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register src="../../../UDC/SimpleServings/Recipe/RecipeList.ascx" tagname="RecipeList" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">

    <form id="form1" runat="server">
    
        <h1 class="titanictitle">Recipe List</h1>
        <div class="contentBox">
            <div class="title2">
                <ul class="listH">
                    <li>View: </li>
                    <li>
                    <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/MyFavoriteRecipeList.aspx") %>' class="favoriteIcon floatR">My Favorites</a>
                    </li>                   
                </ul>

                <asp:HyperLink ID="hlAddRecipe" runat="server" CssClass="add floatR" Text="Add Recipe" 
                    NavigateUrl="~/UI/Page/SimpleServings/Recipe/AddRecipe.aspx" >
                </asp:HyperLink>
            </div>
            <div class="dataList">                
                <div id="listView">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>                
                    <uc1:RecipeList ID="RecipeList1" runat="server" />                    
                </div>
            </div>
        </div>           
    </form>
</asp:Content>


