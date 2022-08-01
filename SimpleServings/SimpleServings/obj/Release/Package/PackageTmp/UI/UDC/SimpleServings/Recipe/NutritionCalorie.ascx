<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NutritionCalorie.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.NutritionCalorie" %>

<ul class="nutritionCal">
    <asp:Repeater ID="rptNutrition" runat="server">
        <ItemTemplate>
            <li>
                <asp:Label ID="lblNutrientInfo" runat="server" Text='<%# Eval("NutrientInfo") %>'>
                </asp:Label>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul> 
