<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Page/dashboardmain.Master" AutoEventWireup="true" CodeBehind="MyFavoriteRecipeList.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Recipe.MyFavoriteRecipeList" %>
<%@ Register src="../../../UDC/SimpleServings/Recipe/RecipeFavoriteList.ascx" tagname="RecipeFavoriteList" tagprefix="uc3" %>	

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">

    <form id="form1" runat="server">
    
        <h1 class="titanictitle">My Favorite Recipe List</h1>
        <div class="contentBox">
           <div class="title2 h2Size">
            <ul class="listH"> 
            <li>View: </li>                 
            <li class="toggleList">
                    <a class="" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx") %>' >All Recipes</a>                      
            </li>  
                </ul>

           <asp:HyperLink ID="hlAddRecipe" runat="server" CssClass="add floatR" Text="Add Recipe" 
                    NavigateUrl="~/UI/Page/SimpleServings/Recipe/AddRecipe.aspx" >
                </asp:HyperLink>            
            </div>
             <h2 class="title2">
                
                </h2>
            

            <div class="dataList">
                <asp:ScriptManager ID="sm" runat="server">
                </asp:ScriptManager>

                <div id="myFavoriteList">
                <asp:UpdatePanel ID="up3" runat="server">
                    <ContentTemplate>
                        <uc3:RecipeFavoriteList ID="myFavoriteList1" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                </div>

            </div>
        </div>           
    </form>
</asp:Content>

