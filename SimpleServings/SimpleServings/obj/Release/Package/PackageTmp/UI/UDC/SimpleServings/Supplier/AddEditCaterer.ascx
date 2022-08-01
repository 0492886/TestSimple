<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditCaterer.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.AddEditCaterer" %>
<%@ Register src="AddEditContactPerson.ascx" tagname="AddEditContactPerson" tagprefix="uc1" %>


		
<asp:Label ID="lblMsg" runat="server"></asp:Label>
<asp:Label ID="lblCatererID" runat="server" Visible="false"></asp:Label>
<div id="divContent" class="contentBox" runat="server">
    <div class="title2 h2Size">
        <asp:Label ID="lblCaterer" runat="server" Text="Sponsor"></asp:Label>

        <asp:LinkButton ID="lnkBtnList" runat="server" CssClass="floatR back"  onclick="lnkBtnList_Click">
            Back to Caterer List
        </asp:LinkButton>
    </div>
    <div class="dataList">
        <div class="dataLeft">
            <div class="dataRow">
                <div class="dataLabel">Caterer Name :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtCatererName" runat="server"></asp:TextBox>
                </div>
            </div>
             <div class="dataRow">
                <div class="dataLabel">Caterer Address :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtCatererAddress" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
        <uc1:AddEditContactPerson ID="ctrlContactPerson" runat="server" />


        <asp:Button ID="btnSave"  CssClass="btn btn_save" runat="server" Text="Save" onclick="btnSave_Click"  />
    
    <div class="clearfix"></div>
</div>