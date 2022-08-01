<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScaledIngredient.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Recipe.ScaledIngredient" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register src="../../../UDC/SimpleServings/Recipe/ScaledIngredient.ascx" tagname="ScaledIngredient" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
 <form id="form" runat="server">     
     <div class="themetitle2">
	<div class="themetitlewrapper">	
	<h1 class="titanictitle">Scaled Recipe</h1>			
	</div>
	</div>
<div class="contentBox">
   
    <div>
    <div class="dataList">
       <uc1:ScaledIngredient ID="ScaledIngredient1" runat="server" />
    </div>
    </div>
</div>
</form>
<style>#menu{display:none}</style>
</asp:Content>

