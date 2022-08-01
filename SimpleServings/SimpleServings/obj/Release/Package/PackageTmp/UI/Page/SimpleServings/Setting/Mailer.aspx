<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../../caseManagementPages.Master" Title="Email" CodeBehind="Mailer.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.Mailer" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/Mailer.ascx" TagName="Mailer" TagPrefix="uc1" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">  
        <uc1:Mailer ID="Mailer1" runat="server" />
</asp:Content>
