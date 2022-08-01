<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PopUpNote.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.PopUpNote" %>

   
<div id="showimage" class="section" style="position:absolute; background:#FFFEEE; width:300px; right:20px; bottom:20px;">
    <div id="dragbar" class="SectionTitle" style="cursor:move;" onmousedown="initializedrag(event)">
        <ilayer width="100%" onSelectStart="return false">
            <layer width="100%" onMouseover="dragswitch=1;if (ns4) drag_dropns(showimage)" onMouseout="dragswitch=0"></layer>
        </ilayer>
        <span>Latest Notes</span>
        <asp:LinkButton CssClass="btn_floatR btn_delete" runat="server" ID="lnkCloseNote" Text="Close" OnClick="lnkCloseNote_Click" OnClientClick="hidebox();" />
    </div>
    <div class="popUpMsgContent">
        <span><asp:Label CssClass="lblMsgFrom" ID="lblSender" runat="server" />&emsp;
        <asp:Label CssClass="popUpMsgTime" ID="lblTime" runat="server" /></span>
        <p><asp:Label CssClass="popUpMsgNote" ID="lblNote" runat="server" /></p>
    </div>
    <asp:Label SkinID="amountFound" CssClass="btn_floatR" ID="lblSummary" runat="server" ForeColor="red" />
    <asp:LinkButton CssClass="btn_floatR btn_next" runat="server" ID="lnkViewAll" Text="View" OnClientClick="hidebox();" OnClick="lnkViewAll_Click"></asp:LinkButton>
</div>