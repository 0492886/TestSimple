<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRecipe.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Recipe.ViewRecipe"  MasterPageFile="~/UI/Page/dashboardmain.Master" %>
<%@ Register src="../../../UDC/SimpleServings/Recipe/ViewRecipe.ascx" tagname="ViewRecipe" tagprefix="uc1" %>


<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">

<script type="text/javascript">
    $(document).ready(function () {
        if (window.location.href.indexOf("ShowHeader=0") > -1) {
            document.querySelector(".header").style.display = 'none';
        }
    });
</script>
    <form id="form1" runat="server">
   	     <h1 class="titanictitle">View Recipe</h1>
        <uc1:ViewRecipe ID="ViewRecipe1" runat="server" />
    </form>
</asp:Content>