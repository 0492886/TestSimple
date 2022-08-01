<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuStatusChangeActionPanel.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuStatusChangeActionPanel" %>

<asp:Label ID="lblKeyID" Visible="false" runat="server"></asp:Label>
<asp:Label ID="lblCurrentStatus" runat="server" Visible="false" ></asp:Label>
<asp:Label ID="lblMsg" runat="server"></asp:Label>

<asp:DataList ID="dlStatusList" runat="server" 
    onitemdatabound="dlStatusList_ItemDataBound">
    <ItemTemplate>
        <li class="li11">
        <asp:Label ID="lblStatusID" Visible="false" runat="server" 
        Text='<%# DataBinder.Eval(Container.DataItem, "CodeID") %>' 
        CssClass="" ></asp:Label>                   
        <asp:HyperLink ID="hlStatus" runat="server" 
        Text='<%# DataBinder.Eval(Container.DataItem, "Comment") %>' CssClass="add"></asp:HyperLink>   
        </li>     
    </ItemTemplate>
</asp:DataList>