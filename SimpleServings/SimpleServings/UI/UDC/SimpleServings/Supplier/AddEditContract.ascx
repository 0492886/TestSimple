<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditContract.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.AddEditContract" %>
<%@ Register src="AddEditContactPerson.ascx" tagname="AddEditContactPerson" tagprefix="uc1" %>

<asp:Label ID="lblMsg" runat="server"></asp:Label>
<asp:Label ID="lblContractID" runat="server" Visible="false"></asp:Label>

<div id="divContent" runat="server" class="contentBox">
    <div class="title2 h2Size">
        <asp:Label ID="lblContract" runat="server" Text="Contract"></asp:Label>
        <asp:LinkButton ID="lnkBtnList" runat="server"  CssClass="floatR back" onclick="lnkBtnList_Click">
            Back to Contract List
        </asp:LinkButton>
    </div>

    <div class="dataList">
        <div class="dataLeft">
          
                <div class="dataLabel">Contract Name :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtContractName" runat="server"></asp:TextBox>
                </div>
            
                <div class="dataLabel">DFTA ID Number :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtContractNumber" runat="server"></asp:TextBox>
                </div>
            
                <div class="dataLabel">Site Address :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtSponsorAddress" runat="server" ></asp:TextBox>
                </div>
           
                <div class="dataLabel">Contract Type :</div>
                <div class="dataInput">
                    <asp:DropDownList ID="ddlContractType" runat="server"></asp:DropDownList>
                </div>
            
                <div class="dataLabel">Sponsor :</div>
                <div class="dataInput">
                    <asp:DropDownList ID="ddlSponsor" runat="server"></asp:DropDownList> 
            </div>
        </div>
    </div>
    <h2 class="title2">Caterers</h2>
    <div class="dataList">
        <div class="dataRow">
            <div class="dataLabel"></div>
            <div class="dataInput">
                <asp:CheckBoxList ID="cblCaterer" runat="server" 
                    CellPadding="0" CellSpacing="0" CssClass="tags widthTags" 
                    RepeatColumns="4" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
            </div>
        </div>
    </div>
    <h2 class="title2">Meals Served</h2>
    <div class="dataList">
        <div class="dataRow">
            <div class="dataLabel"></div>
            <div class="dataInput">
                <asp:CheckBoxList ID="cblMeal" runat="server"
                    CellPadding="0" CellSpacing="0" CssClass="tags" 
                    RepeatColumns="4" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
            </div>
        </div>
    </div>

        <h2 class="title2">Diet Types</h2>
    <div class="dataList">
        <div class="dataRow">
            <div class="dataLabel"></div>
            <div class="dataInput">
                <asp:CheckBoxList ID="cblDietType" runat="server"
                    CellPadding="0" CellSpacing="0" CssClass="tags" 
                    RepeatColumns="4" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
            </div>
        </div>
    </div>


    <uc1:AddEditContactPerson ID="ctrlContactPerson" runat="server" />

    <h2 class="title2">Assigned To</h2>
    <div class="dataList">
        <div class="dataRow w500">
            <div class="dataLabel"></div>
            <div class="dataInput">
                <asp:DropDownList ID="ddlAssignedTo" runat="server"></asp:DropDownList> 
            </div>
        </div>
    </div>

    <asp:Button ID="btnSave"  CssClass="btn btn_save" runat="server" Text="Save" onclick="btnSave_Click" />
    <div class="clearfix"></div>
</div>