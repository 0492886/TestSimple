<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipeSearchList.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Recipe.RecipeSearchList" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register src="../../../UDC/SimpleServings/Recipe/RecipeSearchList.ascx" tagname="RecipeSearchList" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID="containerhome" runat="server">



    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="sm1" runat="server" />
    
        <uc1:RecipeSearchList ID="RecipeSearchList1" runat="server" />
    
    </div>
    </form>

</asp:Content>
