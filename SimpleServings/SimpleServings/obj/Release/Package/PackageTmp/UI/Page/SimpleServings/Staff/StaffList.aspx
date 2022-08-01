<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffList.aspx.cs" MasterPageFile="../../caseManagementPages.Master" Title="Staff List" Inherits="SimpleServings.UI.Page.SimpleServings.Staff.StaffList" %>



<%@ Register Src="~/UI/UDC/SimpleServings/Staff/StaffGrid.ascx"TagName="StaffGrid" TagPrefix="uc1" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
       
        <uc1:StaffGrid ID="StaffGrid1" runat="server" ViewDetails="false" OnLoad="StaffGrid1_Load" />
    
   
    </asp:Content>