<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeRepeater.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.RecipeRepeater" %>
<%@ Register src="NutritionCalorie.ascx" tagname="NutritionCalorie" tagprefix="uc1" %>

<asp:Panel ID="pnPage" CssClass="gridList" runat="server" >
    <asp:Label ID="lblCount" runat="server"></asp:Label> 
    <ul>
    <asp:Repeater ID="rptRecipes" runat="server" onitemdatabound="rptRecipes_ItemDataBound" >
    
        <ItemTemplate>
        
        
        <li class="gridListBox">
            <asp:Label ID="lblRecipeID" runat="server" Visible="false"
                Text = '<%# DataBinder.Eval(Container.DataItem,"RecipeID") %>'>
            </asp:Label>
            

            <h2><%# DataBinder.Eval(Container.DataItem, "RecipeName") %></h2>
            <div class="gridViewImg"><img src="../../../images/meat.jpg" /></div>           
            <h3>Nutrition: </h3>
            <uc1:NutritionCalorie ID="NutritionCalorie1" runat="server" />
            <div class="clearfix"></div>
            <div class="gridviewTags">
            <h3>Tags: </h3>
            <asp:Repeater runat="server" id="rptTags" DataSource='<%# GetRecipeTagsByRecipeID(DataBinder.Eval(Container.DataItem,"RecipeID")) %>'>
                <ItemTemplate>
                    <ul class="nutritionTag">
                        <li>
                            <a href="#"><%# DataBinder.Eval(Container.DataItem, "TagName") %></a>
                        </li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
            </div>
            <div class="clearfix"></div>
            <asp:CheckBox ID="cbCheck" runat="server" Visible="false" />
            <div class="gridviewBtn">
                <asp:HyperLink CssClass="btn_text floatR" ID="hlView" runat="server" NavigateUrl= '<%# String.Format("~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID={0}",DataBinder.Eval(Container.DataItem,"RecipeID")) %>'  Text="View" />
                <asp:HyperLink CssClass="btn_text floatR" ID="hlEdit" runat="server" NavigateUrl= '<%# String.Format("~/UI/Page/SimpleServings/Recipe/EditRecipe.aspx?RecipeID={0}",DataBinder.Eval(Container.DataItem,"RecipeID")) %>'  Text="Edit" />
             <!--  <asp:HyperLink CssClass="btn_text floatR" ID="hlHandle" runat="server" NavigateUrl= '<%# String.Format("~/UI/Page/SimpleServings/Recipe/EditRecipeStatus.aspx?RecipeID={0}",DataBinder.Eval(Container.DataItem,"RecipeID")) %>'  Text="Handle" />-->
            </div>

        </li>

        </ItemTemplate>
        
    </asp:Repeater>
    </ul>
</asp:Panel>





