<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewRecipeNutrition.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.ViewRecipeNutrition" %>
<%@ Register src="NutritionFacts.ascx" tagname="NutritionFacts" tagprefix="uc1" %>
<%@ Register src="NutritionAll.ascx" tagname="NutritionAll" tagprefix="uc2" %>

<table class="nutrition" >
    <tr>
        <td>
            <div class=nutrTitle>Nutrition Facts</div>
        </td>
    </tr>
	<tr id="servings">
		<td>
            <%--<div class="servSize" >Serving Size <asp:Label ID="lblServingSize" runat="server"></asp:Label></div>--%>
            <div class="servSize" style="font-weight:bold"  >Serving Size <asp:Label ID="lblServingSize" runat="server"></asp:Label></div>
        </td>
	</tr>
    
	<tr>
		<td>
            <%--<div class="servAmount" style="font-size: 14Px">Amount Per Serving</div>--%>
            <%--<div class="servAmount"  >Amount Per Serving</div>--%> <%--under line taked out--%>
            <div >Amount Per Serving</div>
        </td>
	</tr>

<%--
    <span class="labelBold">Calories</span>


    <span class="sub>Saturated Fat</span>

    <tr>
		<td>
            <div class="nutrMin">
                <span class="nutrMinName">Vitamin A</span><span class="floatR">1%</span>
            </div>
            <div class="nutrMin">
                <span class="nutrMinName">Vitamin C</span><span class="floatR">1%</span>
            </div>
        </td>
	</tr>

--%>


<%--    <tr id="calories">
		<td>
            <div class="servCal">
                <span class="labelBold">Calories</span> <asp:Label ID="Label1" runat="server"><!-- Use this lable to pull calories--></asp:Label>
                <span class="calsFrom">Calories from Fat <asp:Label ID="Label2" runat="server"><!-- Use this lable to pull fat--></asp:Label></span>
            </div>
            <div class="dailyValue">% Daily Value *</div>
        </td>
	</tr>--%>
<%--
    <tr>
		<td>
            <div class="dailyValue">% Daily Value *</div>
        </td>
	</tr>--%>
</table>

<uc1:NutritionFacts ID="udcNutritionFacts" runat="server" />

<uc2:NutritionAll ID="udcNutritionAll" runat="server" Visible="false" />




<div class="viewBtns">
    <asp:LinkButton ID="lnkBtnShowMore" runat="server" CssClass="viewMore"
        onclick="lnkBtnShowMore_Click">Show More</asp:LinkButton>
    <asp:LinkButton ID="lnkBtnShowLess" runat="server" Visible="false" CssClass="viewLess"
        onclick="lnkBtnShowLess_Click">Show Less</asp:LinkButton>
</div>

