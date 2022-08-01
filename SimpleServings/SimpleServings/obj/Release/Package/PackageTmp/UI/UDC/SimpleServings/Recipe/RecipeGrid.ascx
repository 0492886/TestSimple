<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.RecipeGrid" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Label CssClass="labme" ID="lblCount" runat="server"></asp:Label> 
<asp:Panel ID="pnPage" CssClass="dgContainer" runat="server">         
    <asp:GridView CssClass="DatagridStyle table table-hover" GridLines="None" 
           ID="gvRecipes" runat="server"  AutoGenerateColumns="False" AllowSorting="true" 
           AllowPaging="true" PageSize="50" 
           onpageindexchanging="gvRecipes_PageIndexChanging" onsorting="gvRecipes_Sorting">  <%--OnRowDataBound="gvRecipes_RowDataBound"--%>
     <AlternatingRowStyle CssClass="DatagridStyleAltRow" />
   <PagerSettings Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" FirstPageText="First" LastPageText="Last" />             
 
<Columns>
        
     <asp:TemplateField Visible="true" HeaderText="Recipe ID" sortExpression="RecipeID">
     <ItemTemplate>
                <asp:Label ID="lblRecipeID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Name" SortExpression="RecipeName">
     <ItemTemplate>
            <asp:Label ID="lblRecipeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Status" SortExpression="RecipeStatus">
     <ItemTemplate>
            <asp:Label ID="lblRecipeStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipeStatusText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="View" SortExpression="RecipeView">
     <ItemTemplate>
            <asp:Label ID="lblRecipeView"  runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipeViewText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Contributed By" SortExpression="ContributedBy">
     <ItemTemplate>
            <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContributedBy") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
     <ItemTemplate>
            <asp:Label ID="lblCreatedOn"  runat="server" Width="80" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText=" Rating" SortExpression="RecipeRating" Visible="false">
        <ItemTemplate>
            <cc1:Rating ID="rtRecipe" runat="server" Width="100" ReadOnly="true"
                CurrentRating='<%# DataBinder.Eval(Container.DataItem, "AvgRecipeRating") %>'
                MaxRating='<%# Convert.ToInt32(ConfigurationManager.AppSettings["RecipeMaxRating"]) %>' 
                ToolTip='<%# string.Format("{0} user(s) rated this recipe", DataBinder.Eval(Container.DataItem, "NumTimesRated").ToString()) %>'
                CssClass="ratingStar" StarCssClass="ratingItem" WaitingStarCssClass="SavedIE" FilledStarCssClass="FilledIE" EmptyStarCssClass="EmptyIE">
            </cc1:Rating>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:HyperLinkField 
        DataNavigateUrlFields="RecipeID" 
        ControlStyle-CssClass="" 
        DataNavigateUrlFormatString="~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID={0}"
        Text="View" />
    <asp:HyperLinkField 
        DataNavigateUrlFields="RecipeID" 
        ControlStyle-CssClass="" 
        DataNavigateUrlFormatString="~/UI/Page/SimpleServings/Recipe/EditRecipe.aspx?RecipeID={0}"
        Text="Edit" />
       

    
    </Columns>
    </asp:GridView>
</asp:Panel>