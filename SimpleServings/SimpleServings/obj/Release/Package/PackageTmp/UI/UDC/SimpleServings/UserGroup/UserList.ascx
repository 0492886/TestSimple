<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.UserGroup.UserList" %>
<%@ Register Src="../Staff/StaffGrid.ascx" TagName="StaffGrid" TagPrefix="uc1" %>

<div class="contentBox">

    <div class="title2 h2Size">User List
    <asp:LinkButton ID="btnBackToList" runat="server" class="back floatR" OnClick="btnBackToList_Click" >Back to list</asp:LinkButton>
    </div>
    <div class="ViewPageContainer curved dataList">

        <uc1:StaffGrid ID="StaffGrid1" runat="server" />

</div>
</div>