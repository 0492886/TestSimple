<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkPermissionList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.LinkPermissionList" %>

<asp:Label ID="lblMsg" runat="server" />
<%@ Register Src="~/UI/UDC/Navigation/SideBar.ascx" TagName="LinkRepeater" TagPrefix="uc1" %>
<uc1:LinkRepeater ID="LinkRepeater1" runat="server" />

