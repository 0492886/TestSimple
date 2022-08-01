<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserGroupList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.UserGroupList" %>

<asp:Panel CssClass="dataList" ID="Panel1" runat="server">
    <table style="margin-bottom: 8px">
        <tr>
            <td>
                <asp:Label ID="lblCodeValue" Text="Code Value :" runat="server" style="font-weight:bold"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCodeDescription" runat="server" style="padding-left: 5px;font-weight:bold; color:DarkRed;"></asp:Label>
            </td>
        </tr>
    </table>
    <div class="section">
        <div class="SectionTitle titlePad">
                <span class="dataLabel">User Groups to Exclude</span>
        </div>
        <div class="marginL">
        <asp:LinkButton ID="lnkBtnSelectAll" runat="server" OnClick="lnkBtnSelectAll_Click">Select All</asp:LinkButton>
        <asp:LinkButton ID="lnkBtnDeselectAll" runat="server" OnClick="lnkBtnDeselectAll_Click" EnableViewState="true" >Deselet All</asp:LinkButton>
        </div>
        <div class="ViewPageContainer titlePad">
            <asp:CheckBoxList cssClass="marginL"  ID="cblUserGroup" runat="server" RepeatColumns="8" RepeatDirection="Horizontal"></asp:CheckBoxList>
        </div>
        <asp:Button CssClass="btn btn_save" ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"/>
        <asp:Label ID="lblCodeID" runat="server" Visible="False"></asp:Label>
    </div>
</asp:Panel>
