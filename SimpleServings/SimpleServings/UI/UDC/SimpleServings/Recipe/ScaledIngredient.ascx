<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScaledIngredient.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.ScaledIngredient" %>

<%@ Register src="ViewRecipeSupplement.ascx" tagname="ViewRecipeSupplement" tagprefix="uc1" %>

<div style="overflow:visible !important; height: 100%">
    <div class="title2 h2Size"><asp:Label ID="lblRecipeName" runat="server"> </asp:Label>
         <a href="javascript:window.print()" class="print floatR">Print</a>
    </div>
    <div class="dataLabel marginLeft"><span class="wtitle">New ingredients for : </span><span class="dataInput bold">
        <asp:Label ID="lblScaleTo" runat="server"></asp:Label> serving(s)</span></div><br />
    <div class="dataList">
        <asp:BulletedList CssClass="ingredScaled" ID="bltScaledIngredients" runat="server"></asp:BulletedList>
    </div>

    <br /><br />

    <div style="width:600px;">
        <h2 class="title2">Directions</h2>
        <div class="dataList">
            <uc1:ViewRecipeSupplement ID="directionGrid" RecipeSupplementType="20" runat="server" />
        </div>

        <h2 class="title2">Reqirements</h2>
        <div class="dataList">
            <uc1:ViewRecipeSupplement ID="requirementGrid" RecipeSupplementType="22" runat="server" />
        </div>

        <div style="font-style:italic;">
            "Scaling this recipe may affect the cooking time.  All food should be cooked thoroughly, for the proper length of time, and to the proper internal temperature"
        </div>
    </div>
</div>