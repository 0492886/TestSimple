<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubmitMenuToContracts.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.SubmitMenuToContracts" %>
<%@ Register src="../Supplier/ContractGrid.ascx" tagname="ContractGrid" tagprefix="uc1" %>

<asp:Label ID="lblMsg" runat="server"></asp:Label>
<asp:Panel ID="pnPage" runat="server">
    <asp:Label ID="lblMenuID" runat="server" Visible="false" />
    <uc1:ContractGrid ID="ContractGrid1" runat="server" />
    <asp:Button ID="btnSubmit" runat="server" Visible="false" Text="Submit" onclick="btnSubmit_Click" />   
</asp:Panel>