<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="searchbar.ascx.cs" Inherits="SimpleServings.UI.UDC.Navigation.searchbar" %>

<div class="searchbar">

    <div class="search_input">
        <asp:RadioButton ID="rbPIN" runat="server" GroupName="SearchBy" /><label>PIN</label>
        <asp:RadioButton ID="rbVendorName" runat="server" GroupName="SearchBy" /><label>Vendor</label>
        <asp:RadioButton ID="rbConsultantName" runat="server" GroupName="SearchBy" /><label>Consultant</label>
        <asp:RadioButton ID="rbProjectName" runat="server" GroupName="SearchBy" Checked="True" /><label>Project</label> 
    </div>

    <div class="myZoneUser">
        <em>Welcome,</em> <strong><asp:Label ID="lblUser" runat="server"></asp:Label></strong>
        <span class="splitter1"></span><asp:LinkButton ID="lnkLogOff" runat="server" CausesValidation="False" >logout</asp:LinkButton>
    </div>

    <div class="search_box">
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="False" />
    </div>

</div>