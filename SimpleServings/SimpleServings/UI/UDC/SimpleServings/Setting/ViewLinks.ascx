<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewLinks.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.ViewLinks" %>
<%@ Register Src="~/UI/UDC/Navigation/SideBar.ascx" TagName="LinkRepeater" TagPrefix="uc1" %>


<asp:Label ID="lblMsg" runat="server"></asp:Label>

<asp:Panel ID="pnPage" CssClass="contentBox" runat="server" >
    <div class="h2Size title2">Manage Links
        <asp:LinkButton ID="lnkBAddLink" runat="server" CssClass="add floatR" Text="Add Link" OnClick="lnkBAddLink_Click"></asp:LinkButton>
    </div>
         
    <div class="ViewPageContainer curved dataList">      
        <div class="viewlink2">
            <uc1:LinkRepeater ID="LinkRepeater1" runat="server" />
        </div>
    </div>
    <div class="clearfix"></div>   
</asp:Panel>