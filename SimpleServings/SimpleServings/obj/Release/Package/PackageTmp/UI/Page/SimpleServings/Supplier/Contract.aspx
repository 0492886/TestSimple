<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Supplier.Contract"  MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">  
    <form id="form1" runat="server">
        <h1 class="titanictitle">Contracts</h1>
        <asp:PlaceHolder ID="ctrlPlaceHolder" runat="server"></asp:PlaceHolder>
    </form>
</asp:Content>