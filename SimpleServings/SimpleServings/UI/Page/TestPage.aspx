<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="SimpleServings.UI.Page.TestPage" MasterPageFile="~/UI/Page/dashboardmain.Master"  %>

<%--<%@ Register src="../UDC/SimpleServings/Menu/MenuGrid.ascx" tagname="MenuGrid" tagprefix="uc1" %>
<%@ Register src="../UDC/TestLabel.ascx" tagname="TestLabel" tagprefix="uc2" %>

<%@ Register src="../UDC/SimpleServings/Menu/AddEditMenuThreshold.ascx" tagname="AddEditMenuThreshold" tagprefix="uc3" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form2" runat="server">
    <asp:Panel ID="pnlID" runat="server" Visible="true">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <%-- <uc2:TestLabel ID="TestLabel1" runat="server" RecipeSupplementType="20" />--%>
        <asp:UpdatePanel ID="Panel1" runat="server">
            <ContentTemplate>
        <div>
            <div class="title2">My Rating</div>
            <cc1:Rating ID="Rating1" runat="server"
             MaxRating="5"
                            CurrentRating="1"
                            CssClass="ratingStar"
                            StarCssClass="ratingItem"
                            WaitingStarCssClass="SavedIE"
                            FilledStarCssClass="FilledIE"
                            EmptyStarCssClass="EmptyIE" AutoPostBack="True" OnChanged="Rating1_Changed"> 

            </cc1:Rating>
            <asp:Label ID="labelCaption1" runat="server" Text="Selected value: " />
            <asp:Label ID="labelValue1" runat="server" Text=""></asp:Label>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <div class="dataList">
          <div class="title2">My Menu</div>     
            <asp:Label ID="lblMsg" runat="server" CssClass="hidden_msg"></asp:Label>
      <%--      <uc1:MenuGrid ID="MenuGrid1" runat="server" />   --%>         
        </div>
        <br />
        <div class="dataList">
          <div class="title2">My Draft
            </div>     
            <asp:Label ID="Label1" runat="server" CssClass="hidden_msg"></asp:Label>
   <%--         <uc1:MenuGrid ID="MenuGrid2" runat="server" />      --%>      
        </div>        
        
<%--    <uc2:TestLabel ID="TestLabel2" runat="server" RecipeSupplementType="21" />--%>
    </asp:Panel>
  <%--  <uc3:AddEditMenuThreshold ID="AddEditMenuThreshold1" runat="server" />--%>
    <asp:LinkButton Text="Test Link" PostBackUrl="http://w15mtc17j076/SimpleServings/UI/Page/SimpleServings/Staff/ForgotPassword.aspx"  runat="server" />
    </form>
</asp:Content>



    
       