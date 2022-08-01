<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideBar.ascx.cs" Inherits="SimpleServings.UI.UDC.Navigation.SideBar" %>

<asp:Panel ID="pnPage"  runat="server">
<div class="padLink">
    <asp:LinkButton CssClass="btn_text" ID="lnkBtnSelectAll" runat="server" OnClick="lnkBtnSelectAll_Click" Visible="false">Select All</asp:LinkButton>
    <asp:LinkButton CssClass="btn_text" ID="lnkBtnDeselectAll" runat="server" OnClick="lnkBtnDeselectAll_Click" Visible="false" >Deselect All</asp:LinkButton>
</div>
    <div class="siba">
        <ul>
            <asp:Repeater ID="rpLinks" runat="server" OnItemDataBound="rpLinks_ItemDataBound" >

                <ItemTemplate>
               
                     <li>
                    
                                <asp:Label CssClass="dataLabel hide" ID="lblCategory" runat="server" Text='<%#Eval("CategoryText")%>' />                        
                                <asp:Label CssClass="dataLabel" ID="lblLinkID" runat="server" Text='<%#Eval("LinkID")%>' Visible="false" />
                                <asp:Label CssClass="dataLabel"  ID="lblLinkType" runat="server" Text='<%#Eval("LinkType")%>' Visible="false" />               
                                <asp:CheckBox  CssClass="dataInput"  SkinID="ChkBoxStyle" ID="cbSelected" runat="server" Visible="false" />
                                <asp:LinkButton  CssClass="edit" ID="lnkbEdit" runat="server" EnableViewState="true" Text="Edit" Visible="false" CommandArgument='<%# Eval("LinkID") %>' OnClick="lnkbEdit_Click" />
                                <asp:LinkButton  CssClass="dataInput floatL w35 h2Size marginR30"  ID="lnkbHyperlink" runat="server" EnableViewState="true" Text='<%# Eval("Description") %>' CommandArgument='<%# Eval("Hyperlink") %>' CommandName='<%# Eval("LinkType") %>' OnClick="lnkbHyperlink_Click" />
                            
                     </li>
                     
                </ItemTemplate>

            </asp:Repeater>
        </ul>
    </div>

</asp:Panel>


