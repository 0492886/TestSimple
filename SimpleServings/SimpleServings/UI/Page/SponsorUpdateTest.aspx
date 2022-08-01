<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SponsorUpdateTest.aspx.cs" Inherits="SimpleServings.UI.Page.SponsorUpdateTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMsg" runat="server"></asp:Label><br />
        <asp:FileUpload ID="fileUplaod" runat="server" Width="532px" /> <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    </div>
    </form>
</body>
</html>
