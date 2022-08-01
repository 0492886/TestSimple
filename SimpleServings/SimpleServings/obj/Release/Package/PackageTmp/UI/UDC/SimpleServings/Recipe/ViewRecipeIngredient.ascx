<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewRecipeIngredient.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.ViewRecipeIngredient" %>



<asp:GridView ID="gvRecipeIngredient" runat="server" AutoGenerateColumns="false">
    <%--CssClass="ingred" HeaderStyle-CssClass="hideRow"--%>
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <span class="dblArrow"> <%= (this.ShowArrow == true) ? "&raquo;" : "&nbsp;&nbsp;" %> </span>
           <%--   <span class="li1"></span>--%>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("IngredientDescription") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>