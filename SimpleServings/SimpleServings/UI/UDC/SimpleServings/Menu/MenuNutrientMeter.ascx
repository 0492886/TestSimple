<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuNutrientMeter.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuNutrientMeter" %>

<ul class="alertPanel">
    <asp:Repeater ID="rptNutrient" runat="server">
        <ItemTemplate>
            <li>
                <asp:Label ID="lblNutrient" CssClass='<%# Eval("MeterColor") %>' runat="server" Text='<%# Eval("NutrientName") %>'>
                </asp:Label>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul> 
