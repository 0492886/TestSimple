<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusChangeSubmission.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.StatusChangeSubmission" %>


<asp:Label ID="lblMsg" runat="server"></asp:Label>
<asp:Panel ID="pnPage" CssClass="contentBox" runat="server">

<h2 class="title2">Status</h2>
<div class="dataList">
    <div class="dataRow">
        <div class="dataLabel">Change Status :</div>
        <div class="dataInput">
            <asp:DropDownList ID="ddlRecipeStatus" Width="400" runat="server"></asp:DropDownList> 
        </div>
    </div>
    <div class="dataRow">
        <div class="dataLabel">Description :</div>
        <div class="dataInput">
            <asp:TextBox ID="txtCustomMessage" runat="server" TextMode="MultiLine" Height="120px" Width="400" ></asp:TextBox>
        </div>
    </div>
</div>

<asp:Button ID="btnEditRecipeStatus" CssClass="btn btn_save" runat="server" 
        Text="Save" onclick="btnEditRecipeStatus_Click" />
<button class="btn saveClose rightFloat hide" type="button">Close</button>

<div class="clearfix"></div>   
</asp:Panel>
