<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCode.aspx.cs" MasterPageFile="~/UI/Page/dashboardmain.Master" Title="Add Code" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.AddCode" %>

<%@ Register Src="../../../UDC/SimpleServings/Setting/AddCode.ascx" TagName="AddCode" TagPrefix="uc1" %>


<asp:Content ID="ct1"  ContentPlaceHolderID="containerhome" runat="server">
 
 <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <uc1:AddCode ID="AddCode1" runat="server" />
 </form>

</asp:Content>