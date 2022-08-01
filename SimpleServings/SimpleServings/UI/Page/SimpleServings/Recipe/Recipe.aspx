<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recipe.aspx.cs" Inherits="SimpleServings.UI.Page.Recipe" MaintainScrollPositionOnPostback="true" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>
<%-- 
<%@ Reference Control="~/UI/UDC/SimpleServings/UserGroup/UserGroupList.ascx"%>
<%@ Reference Control="~/UI/UDC/SimpleServings/Setting/CodeList.ascx" %>
<%@ Reference Control="~/UI/UDC/SimpleServings/Staff/MyProfile.ascx" %>
<%@ Reference Control="~/UI/UDC/SimpleServings/Staff/StaffSearchControl.ascx" %>
--%>


<%@ Register TagPrefix="uc1" TagName="navigationbar" Src="~/UI/UDC/Navigation/navigationbar.ascx" %>
<%--@Register TagPrefix="uc1" TagName="quicklinks" Src="../UDC/v2/quicklinks.ascx"--%>

<%@ Register TagPrefix="uc1" TagName="header" Src="~/UI/UDC/Navigation/header.ascx" %>


<%@ Register Src="~/UI/UDC/Navigation/AccordionMenu.ascx" TagName="SideBar" TagPrefix="uc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="~/UI/UDC/SimpleServings/Recipe/ViewRecipeIngredient.ascx" tagname="ViewRecipeIngredient" tagprefix="uc3" %>
<%@ Register src="~/UI/UDC/SimpleServings/Recipe/RecipeGrid.ascx" tagname="RecipeGrid" tagprefix="uc4" %>
 

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    
<link rel="stylesheet" type="text/css" href="../../UI/css/screen_styles.css" />
<link rel="stylesheet" type="text/css" href="../../UI/css/revstyle.css" media="screen" />
<script type="text/javascript"  src="<%# Page.ResolveUrl("~/UI/js/jquery-1.9.1.js") %>"></script>
<script type="text/javascript"  src="<%# Page.ResolveUrl("~/UI/js/jquery-ui.js") %>"></script>
<script type="text/javascript" src="<%# Page.ResolveUrl("~/UI/js/custom.js") %>"></script>
      <script src="../../../js/custom.js" type="text/javascript"></script>

<form id="test2" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="themetitle2">
            <div class="themetitlewrapper">
                <h1 class="titanictitle">Recipe</h1>
            </div>
        </div>
                
<div class="contentBox">
                    <div class="title2 h2Size"> 
                        Our Recipes
                        <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/MyFavoriteRecipeList.aspx") %>' class="favoriteIcon floatR">My Favorites</a>
                        <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx") %>' class="searchIcon floatR">Search/See All Recipes</a>
                    </div>


<%--<div style="width:98%; height:100%; border-top: 1px solid #e5e5e5;"> &nbsp;<div style="padding:10px; margin:5px; width:100%; height:100%; border-radius:3px;">                       
<input type="search" class="recipeSearchBox" placeholder="Search Recipe by Name..." id="recipeSearchBox" onkeypress="return recipeSearchBoxKeyPress(event)" />
</div>--%>
                         

                        <div class="showcase-cntnr">
                            <ul class="cat-cntnr">
                                <li>
                                    <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=24") %>'>
                                        <img alt="Appetizer" src="../../../images/appetizerPhoto.jpg"></a>
                                    <span><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=24") %>'>Appetizers</a></span>
                                </li>
                                <li>
                                    <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=149") %>'>
                                        <img alt="Breakfast" src="../../../images/breakfastPhoto.jpg"></a>
                                    <span><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=149") %>'>Breakfast</a></span>
                                </li>
                                <li>
                                    <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=45") %>'>
                                        <img alt="Grains" src="../../../images/grainsPhoto.jpg"></a>
                                    <span><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=45") %>'>Grains</a></span>
                                </li>
                                <li>
                                    <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=23") %>'>
                                        <img alt="Entree" src="../../../images/entreePhoto.jpg"></a>
                                    <span><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=23") %>'>Entrees</a></span>
                                </li>
                                <li>
                                    <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=133") %>'>
                                        <img alt="Vegetarian" src="../../../images/vegePhoto.jpg"></a>
                                    <span><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=133") %>'>Vegetarian</a></span>
                                </li>
                                <li>
                                    <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=25") %>'>
                                        <img alt="Vegetables" src="../../../images/vege2Photo.jpg"></a>
                                    <span><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=25") %>'>Vegetables</a></span>
                                </li>
                                <li>
                                    <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=78") %>'>
                                        <img alt="Dairy-Free" src="../../../images/nondairyPhoto.jpg"></a>
                                    <span><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=78") %>'>Dairy-Free</a></span>
                                </li>

                            </ul>
                        </div>

                        <div class="clear"></div>
                         



        <div  class="contentBox marginTophack">
            <asp:Panel runat="server" CssClass="pnlCategorySearch" >
                <div class="title2 h2Size"> Advanced Search By Category</div>
             </asp:Panel>

            <asp:Repeater runat="server" ID="rpCategories"> 
                <ItemTemplate> 
                      <div class="Expandcontainer">
                          <%--<div> --%>
                            <div class="Expandheader" onclick="ExpandheaderKeyPress(this)"> 
                                <span id="rpHeader" runat="server"><%# Container.DataItem %></span>
                            </div>
                             
                            <div class="cbtags"> 
                              <asp:CheckBoxList ID="cbTags" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">                                  
                              </asp:CheckBoxList>
                           </div>
                      </div>
                </ItemTemplate> 
            </asp:Repeater>

         <div style="width:98%; height:100%; border-top: 1px solid #e5e5e5;"> &nbsp;<div style="padding:10px; margin:5px; width:88%; height:100%; border-radius:3px;"><%--width:80%;--%>
           <%-- <asp:Label ID="Label1" class="title2 h2Size" runat="server" Text="Search Recipe by Name: "></asp:Label>--%>
             <br />
              <input type="text" runat="server" class="recipeSearchBox" placeholder="Search Recipe by Recipe ID or Recipe Name..." id="txtsearch" spellcheck="true" />
        
             
             <%-- <ASPNetSpell:SpellTextBox   ID="txtsearch" runat="server" Style="overflow: hidden;"  class="recipeSearchBox"  Height="16px" Width="696px" TextMode="SingleLine"  Text="" BorderWidth="1px"  BorderColor="LightGray"  ></ASPNetSpell:SpellTextBox>
            --%>
         </div>

         <asp:Button runat="server" ID="btnSearch" Text="Search" style="width:150px !important; background-color:beige; float:left" CssClass="btn btn_save" OnClick="btnSearch_Click"/> 

       </div>
         <div class="clear"></div>

        <div class="contentBox marginTophack">
            <div class="title2 h2Size"> Recipe Search Result:</div>                   

            <asp:Label runat="server" ID="lblsearchMsg" Font-Bold="true" style="margin-left:10px;"></asp:Label>
            <uc4:RecipeGrid ID="RecipeGrid1" runat="server" />
        </div>

     </div>
</div>



</form>


<script type="text/javascript">


    $(window).load(function (e) {

    var selectedTags = [];
    $('.cbtags input:checked').each(function () {
        selectedTags.push($(this).attr('id'));
    });
    var spans = [];

    for (var i = 0; i < selectedTags.length; i++)
    {
        var temp = document.getElementById(selectedTags[i]);
        $tags = $(temp).closest('.cbtags');

        var tagId = $tags.context.id;
        tagId = tagId.substring(0, tagId.indexOf("cbTags"));

        var header = $tags.closest('.Expandheader');

        if (jQuery.inArray(tagId, spans) == -1) {
            spans.push(tagId);
            $tags.slideToggle(300);
        }        
    }    
});
    
   
</script>

<style>

.cbtags input[type=checkbox]:checked {
background: #FF6634;
}

</style>


</asp:Content>


