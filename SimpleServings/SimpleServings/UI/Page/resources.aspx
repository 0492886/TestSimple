<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resources.aspx.cs" Inherits="SimpleServings.UI.Page.resources" MasterPageFile="~/UI/Page/dashboardmain.Master" %>


<%@ Register src="../UDC/SimpleServings/Resource/Resource.ascx" tagname="Resource" tagprefix="uc1" %>


<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server"> 
         <uc1:Resource ID="Resource1" runat="server" /> 
    </form>
</asp:Content>
