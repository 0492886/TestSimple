<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStaffAccessLevel.aspx.cs"   MasterPageFile="~/UI/Page/dashboardmain.Master" Inherits="SimpleServings.UI.Page.SimpleServings.Staff.AddStaffAccessLevel" %>

<%@ Register src="../../../UDC/SimpleServings/Staff/AddStaffAccessLevel.ascx" tagname="AddStaffAccessLevel" tagprefix="uc1" %>


<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
    <h1 class="titanictitle">Settings</h1>
        <uc1:AddStaffAccessLevel ID="AddStaffAccessLevel1" runat="server" IsUsedInWizard="false"/>
    
    </form>
    </asp:Content>	
