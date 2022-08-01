<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewRecipeSupplement.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.ViewRecipeSupplement" %>



<asp:GridView ID="gvRecipeSupplement" runat="server" CssClass="ingred"  HeaderStyle-CssClass="hideRow" AutoGenerateColumns="false">
<Columns>
    <asp:TemplateField>
        <ItemTemplate>
            <span class="dblArrow">&raquo;</span>
            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("DescriptionInOrder") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>