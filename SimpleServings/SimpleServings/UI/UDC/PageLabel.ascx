<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageLabel.ascx.cs" Inherits="SimpleServings.UI.UDC.PageLabel" %>
<%@ Register Src="SimpleServings/Staff/AddStaffNote.ascx" TagName="AddStaffNote" TagPrefix="uc1" %>




<%@ Register src="SmallLabel.ascx" tagname="SmallLabel" tagprefix="uc2" %>

 <uc2:SmallLabel ID="SmallLabel1" runat="server" />


<div class="chatBubble">
   
    <asp:label id="lblAddNote" runat="server" CssClass="btn_chat" Text="Leave a note" />
    <asp:Panel runat="server" ID="pnlAddNote1">
        <uc1:AddStaffNote ID="AddStaffNote1" runat="server" />  
    </asp:Panel>
</div>