<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationBar.ascx.cs" Inherits="SimpleServings.UI.UDC.Navigation.NavigationBar" %>

<ul class="navigation">
  
	<li>
	    <asp:LinkButton ID="lnkBMyZone" runat="server" Text="myZone" OnClick="lnkBMyZone_Click" />
		<%-- <a id="A1" href="~/UI/Page/myzone.aspx" runat="server" >myZone</a> --%>
	</li>
	<li>
		<a id="A2" href="~/UI/Page/Home.aspx" runat="server">home</a>
	</li>
</ul>
