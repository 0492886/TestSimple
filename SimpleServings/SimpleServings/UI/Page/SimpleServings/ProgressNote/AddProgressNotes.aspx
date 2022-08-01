<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProgressNotes.aspx.cs" MasterPageFile="../../caseManagementPages.Master" Title="Add Case Note" Inherits="SimpleServings.UI.Page.SimpleServings.ProgressNote.AddProgressNotes" ValidateRequest="false"  %>
<%@ Register Src="../../../UDC/SimpleServings/ProgressNote/AddProgressNote.ascx" TagName="AddProgressNote" TagPrefix="uc1" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="container1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="fatortitle">Add Note</div>
        <a class="linksright lnkCloseStyle"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>
        <div ID="divAddAddress" class="ViewPageContainer" runat="server">
            <div class="section">
                <uc1:AddProgressNote ID="AddProgressNote1" runat="server" />
            </div>
        </div>
</asp:Content>