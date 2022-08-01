<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NutritionAll.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.NutritionAll" %>

<asp:DataList ID="dlRecipeNutrition" runat="server" CssClass="nutrition nutrFacts" OnItemDataBound="dlRecipeNutrition_ItemDataBound">
<ItemTemplate>

    <asp:Panel ID="pnlRegular" runat="server" CssClass="nutrList">
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NutritionFactName") %>'></asp:Label>
        <asp:Label ID="Label2" runat="server" Text='<%# Eval("ValueRounding") %>'></asp:Label>
        <asp:Label ID="Label3" runat="server" Text='<%# Eval("UnitName") %>'></asp:Label>
        <asp:Label ID="Label4" runat="server" CssClass="floatR" Text='<%# Eval("PercentageText") %>'></asp:Label>
    </asp:Panel>

    <asp:Panel ID="pnlSpecial" runat="server" Visible="false">
        <asp:Label ID="Label5" runat="server" Text='<%# Eval("NutritionFactInfo") %>'></asp:Label>
    </asp:Panel>

</ItemTemplate>
</asp:DataList>