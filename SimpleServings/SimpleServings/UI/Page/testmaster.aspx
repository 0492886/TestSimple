<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testmaster.aspx.cs" Inherits="SimpleServings.UI.Page.testmaster" MasterPageFile="~/UI/Page/caseManagementPages.Master" %>



<%@ Register src="../UDC/SimpleServings/Recipe/AddRecipe.ascx" tagname="AddRecipe" tagprefix="uc1" %>



<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="container1">
   


 




    <uc1:AddRecipe ID="AddRecipe2" runat="server" />
   


 




</asp:Content>