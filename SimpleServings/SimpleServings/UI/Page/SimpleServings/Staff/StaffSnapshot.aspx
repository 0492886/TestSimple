<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../../caseManagementPages.Master" Title="StaffSnapshot" CodeBehind="StaffSnapshot.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Staff.StaffSnapshot" EnableViewState="false"%>

<%@ Register Src="../../../UDC/SimpleServings/Staff/StaffSnapshot.ascx" TagName="StaffSnapshot"
    TagPrefix="uc1" %>
<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">
        <uc1:StaffSnapshot ID="StaffSnapshot1" runat="server">
        </uc1:StaffSnapshot>
</asp:Content>
