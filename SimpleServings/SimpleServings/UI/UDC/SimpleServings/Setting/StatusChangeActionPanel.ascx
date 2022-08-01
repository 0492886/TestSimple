<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusChangeActionPanel.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.StatusChangeActionPanel" %>


<asp:Label ID="lblKeyID" Visible="false" runat="server"></asp:Label>
<asp:Label ID="lblCurrentStatus" runat="server" Visible="false" ></asp:Label>
<asp:Label ID="lblMsg" runat="server"></asp:Label>

<asp:DataList ID="dlStatusList" runat="server" CssClass="actionBtns"      
    onitemdatabound="dlStatusList_ItemDataBound">
    <ItemTemplate>
        <asp:Label ID="lblStatusID" Visible="false" runat="server" 
        Text='<%# DataBinder.Eval(Container.DataItem, "CodeID") %>' CssClass="check" >
        </asp:Label>  
                         
        <asp:HyperLink ID="hlStatus" runat="server" 
        Text='<%# DataBinder.Eval(Container.DataItem, "Comment") %>'  CssClass="check">
        </asp:HyperLink>   
    </ItemTemplate>
</asp:DataList>

