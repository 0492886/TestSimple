<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForcePasswordChange.aspx.cs" MasterPageFile="~/UI/Page/dashboardmain.Master" Title="PasswordChange" Inherits="SimpleServings.UI.Page.SimpleServings.Staff.ForcePasswordChange" %>

<%@ Register Src="../../../UDC/SimpleServings/Staff/AddEditAccountInfo.ascx" TagName="AddEditAccountInfo"
    TagPrefix="uc1" %>



<asp:Content ID="Content1"  ContentPlaceHolderID="containerhome" runat="server">

<script type="text/javascript" src="../../UI/Javascript/customScripts.js"></script>

  <h1 class="titanictitle">Password Recovery</h1>

        <form ID="Form1" runat="server">
<div class="padLink2">            
You are required to change your password when you first log in and when your account is unlocked. <br />

Please make sure the email address we have on file is valid.
</div>

        <uc1:AddEditAccountInfo ID="AddEditAccountInfo1" runat="server" />
        </form>
    
 </asp:Content>
