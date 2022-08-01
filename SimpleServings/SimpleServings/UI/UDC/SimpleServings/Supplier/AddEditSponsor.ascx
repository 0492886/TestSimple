<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditSponsor.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.AddEditSponsor" %>
<%@ Register src="AddEditContactPerson.ascx" tagname="AddEditContactPerson" tagprefix="uc1" %>


<asp:Label ID="lblMsg" runat="server"></asp:Label>
<asp:Label ID="lblSponsorID" runat="server" Visible="false"></asp:Label>

<div id="divContent" runat="server" class="contentBox">
    <div class="title2 h2Size">
        <asp:Label ID="lblSponsor" runat="server" Text="Sponsor"></asp:Label>
        <asp:LinkButton ID="lnkBtnList" runat="server" CssClass="floatR back" onclick="lnkBtnList_Click">
            Back to Sponsor List
        </asp:LinkButton>
    </div>
    <div class="dataList">
        <div class="dataLeft">
            <div class="dataRow">
                <div class="dataLabel">Sponsor Name :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtSponsorName" runat="server" ></asp:TextBox>
                </div>
            </div>
            <div class="dataRow">
                <div class="dataLabel">Sponsor Address :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtSponsorAddress" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <uc1:AddEditContactPerson ID="ctrlContactPerson" runat="server" />

    <asp:Button ID="btnSave"  CssClass="btn btn_save" runat="server" Text="Save" onclick="btnSave_Click" />

    <div class="clearfix"></div>
</div>