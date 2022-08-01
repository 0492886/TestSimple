<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageCategoriesandTags.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.ManageCategoriesandTags" %>


<asp:Label ID="lblMsg" runat="server"></asp:Label>

<asp:Panel ID="pnPage" runat="server" CssClass="contentBox">
 <h2 class="title2">Categories and Tags Management</h2>


<div style="margin: 10px;">
    <div class="dataRow w500">
        <div class="dataLabel">Recipe Categories :</div>
    
        <br />
    
    <div class="dataInput">
            <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cblTags_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>

    <br />
    <br />

    <div class="dataLeft" style="margin-top:20px;">
        <div class="dataRow">
            <div class="dataLabel">Associated Recipe Tags :</div>
            <br />
            <div class="dataInput">
                <asp:CheckBoxList ID="cblTags" CssClass="tags" runat="server" RepeatColumns="2" RepeatDirection="Vertical" ></asp:CheckBoxList>
            </div>
        </div>
    </div>


    <div class="dataLeft">
        <div style="margin:10px;">
            <asp:Button ID="btnSave" runat="server" Text="Save"  CssClass="btn" OnClick="btnSave_Click"  />
            <input type="button" ID="btnCancel" value="Cancel" class="btn" onclick="btnCancelClick()"/>
        </div>


    </div>
</div>

</asp:Panel>