<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewCaterer.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.ViewCaterer" %>
<%@ Register src="ViewContactPerson.ascx" tagname="ViewContactPerson" tagprefix="uc1" %>

<asp:Label ID="lblCatererID" runat="server" Visible="false"></asp:Label>
<div class="contentBox view">
    <div class="title2 h2Size">
        <asp:Label ID="lblCaterer" runat="server" Text="View Caterer"></asp:Label>
        <asp:LinkButton ID="lnkBtnList" runat="server" onclick="lnkBtnList_Click" CssClass="back floatR">
            Back to Caterer List
        </asp:LinkButton>
        <asp:LinkButton ID="lnkBtnEdit" runat="server" onclick="lnkBtnEdit_Click" CssClass="edit floatR">
            Edit Caterer
        </asp:LinkButton>
        <asp:LinkButton CssClass="deleteIcon floatR"  ID="lnkBtnDeactivate" 
            runat="server" CommandName="Remove" oncommand="lnkBtnDeactivate_Command">Remove</asp:LinkButton>
    </div>
    <div class="dataList">
        <div class="dataRow">
            <div class="dataLabel">Caterer Name :</div>
            <div class="dataInput">
                <asp:Label ID="lblCatererName" runat="server"></asp:Label>
            </div>
        </div>
        <div class="dataRow">
            <div class="dataLabel">Caterer Address :</div>
            <div class="dataInput">
                <asp:Label ID="lblCatererAddress" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <uc1:ViewContactPerson ID="ctrlViewPerson" runat="server" />
</div>