<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewSponsor.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.ViewSponsor" %>
<%@ Register src="ViewContactPerson.ascx" tagname="ViewContactPerson" tagprefix="uc1" %>


<asp:Label ID="lblSponsorID" runat="server" Visible="false"></asp:Label>
<asp:Panel ID="pnPage" CssClass="contentBox view" runat="server">
    <div class="title2 h2Size">
        <asp:Label ID="lblSponsor" runat="server" Text="View Sponsor"></asp:Label>
        
        <asp:LinkButton ID="lnkBtnList" runat="server" onclick="lnkBtnList_Click" CssClass="back floatR">
            Back to Sponsor List
        </asp:LinkButton>
        <asp:LinkButton ID="lnkBtnEdit" runat="server" onclick="lnkBtnEdit_Click" CssClass="edit floatR">
            Edit Sponsor
        </asp:LinkButton>

        <asp:LinkButton CssClass="deleteIcon floatR"  ID="lnkBtnDeactivate" 
            runat="server" CommandName="Remove" oncommand="lnkBtnDeactivate_Command">Remove</asp:LinkButton>
    </div>
    <div class="dataList">
        <div class="dataRow">
            <div class="dataLabel">Sponsor Name :</div>
            <div class="dataInput">
                <asp:Label ID="lblSponsorName" runat="server"></asp:Label>
            </div>
        </div><br />
        <div class="dataRow">
            <div class="dataLabel">Sponsor Address :</div>
            <div class="dataInput">
                <asp:Label ID="lblSponsorAddress" runat="server"></asp:Label>
            </div>
        </div><br />
    </div>
    <uc1:ViewContactPerson ID="ctrlViewPerson" runat="server" />
    <div class="clearfix"></div>
</asp:Panel>