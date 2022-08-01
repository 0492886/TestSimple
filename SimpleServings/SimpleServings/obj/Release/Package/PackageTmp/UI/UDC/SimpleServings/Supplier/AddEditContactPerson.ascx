<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditContactPerson.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.AddEditContactPerson" %>

<asp:Label ID="lblPersonID" runat="server" Visible="false"></asp:Label>

<h2 class="title2">
    <asp:Label ID="lblPerson" runat="server" Text="Contact Person"></asp:Label>
</h2>
<div class="dataList">
    <div class="dataLeft">
        <div class="dataRow">
            <div class="dataLabel">First Name :</div>
            <div class="dataInput">
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="dataRow">
            <div class="dataLabel">Last Name :</div>
            <div class="dataInput">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="dataRow">
            <div class="dataLabel">Address :</div>
            <div class="dataInput">
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="dataRow">
            <div class="dataLabel">Phone :</div>
            <div class="dataInput">
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="dataRow">
            <div class="dataLabel">Email :</div>
            <div class="dataInput">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
