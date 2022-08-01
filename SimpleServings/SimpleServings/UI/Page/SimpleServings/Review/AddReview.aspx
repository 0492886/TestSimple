<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../../caseManagementPages.Master" Title="Add Review"  CodeBehind="AddReview.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Review.AddReview" %>

<%@ Register Src="../../../UDC/SimpleServings/Review/AddReview.ascx" TagName="AddReview" TagPrefix="uc1" %>



<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <a class="linksright lnkCloseStyle"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>
           <uc1:AddReview ID="AddReview1" runat="server">
        </uc1:AddReview>
</asp:Content>
