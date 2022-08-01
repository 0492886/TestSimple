<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeSearchRepeater.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.RecipeSearchRepeater" %>
 
 


<asp:Panel ID="pnPage" runat="server"  CssClass="menuList">
    <asp:Label ID="lblCount" runat="server"></asp:Label> 

 
<asp:Repeater ID="rptRecipes" runat="server"  >   
    <ItemTemplate>
        <div class="menuItem">    
                    
            
            <div class="draggable" ondblclick="openViewRecipe(<%# Eval("RecipeID") %>)">
           <asp:Label ID="lblRecipeID" CssClass="recipeId" runat="server" style="display:none" onmousedown="HideMenu('contextMenu');" onmouseup="HideMenu('contextMenu');"
            Text = '<%# DataBinder.Eval(Container.DataItem,"RecipeID") %>'>
            </asp:Label>  
                <asp:Label ID="lblRecipeName"  runat="server" 
                Text = '<%# DataBinder.Eval(Container.DataItem, "RecipeName") %>' 
                ToolTip='<%# String.Format("Contributed By: {0}\nRecipe View: {1}", DataBinder.Eval(Container.DataItem, "ContributedBy"), DataBinder.Eval(Container.DataItem, "RecipeViewText")) %>'>
                </asp:Label>
            </div>
            
        </div> 
    </ItemTemplate>
</asp:Repeater>
</asp:Panel>



