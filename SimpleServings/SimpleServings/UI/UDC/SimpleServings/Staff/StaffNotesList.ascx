<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffNotesList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.StaffNotesList" %>

<div class="fatortitle">My Notes</div>

<asp:Panel ID="pnPage" CssClass="ViewPageContainer section" runat="server">
    <div class="SectionTitle">
        <asp:Label CssClass="amountFound" ID="lblSummary" runat="server" Text=""/>
    </div>

    &emsp;<asp:CheckBox  SkinID="ChkBoxStyle"  ID="chxShowEntire" runat="server" Text="Show entire note body" AutoPostBack="True" OnCheckedChanged="chxShowEntire_CheckedChanged"/> 
    &emsp;<asp:CheckBox  SkinID="ChkBoxStyle"  ID="chxShowNew" runat="server" Text="Show new notes only" AutoPostBack="True" Checked="true" OnCheckedChanged="chxShowNew_CheckedChanged"/> 
    <br /><br />
    <asp:DataList ID="dlStaffNotes" runat="server" DataKeyField="NoteID" CssClass="noteStretch">
        <ItemTemplate>
            <div class="noteClass">
                <asp:LinkButton CssClass="btn_floatR ActivityEmail"  ID="lnkMarkAsRead" runat="server" Visible='<%# !Convert.ToBoolean(Eval("IsRead")) %>' CommandArgument='<%# Eval("NoteID") %>' OnClick="lnkMarkAsRead_Click">Mark As Read</asp:LinkButton>
                <strong>From : </strong><asp:Label ID="lblCratedBy" ForeColor="steelblue" runat="server" Text='<%# Eval("CreatedByText") %>' />&emsp;
                <strong>To : </strong><asp:Label ID="lblTargetStaff" ForeColor="steelblue" runat="server" Text='<%#Eval("TargetStaffIDText") %>' />&emsp;
                <strong>Created On : </strong><asp:Label ID="lblCreatedOn" ForeColor="steelblue" runat="server" Text='<%# Eval("CreatedOn") %>' />&emsp;
                <br /><br />
                <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Note") %>' Font-Size="11pt" ForeColor='<%# Convert.ToBoolean(Eval("IsRead"))? System.Drawing.Color.Gray: System.Drawing.Color.Black %>' />
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Panel>