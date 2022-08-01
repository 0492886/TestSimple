<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEmail.aspx.cs" Inherits="SimpleServings.UI.Page.TestEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ul>
        <li>From:<asp:Label runat="server" ID="lblForm" /></li> 
        <li>To :
        <asp:DropDownList ID="ddlSendTo" runat="server">
        </asp:DropDownList>
        </li>
        <li>This is a message:<asp:Literal ID="Literal1" runat="server"></asp:Literal></li>
            <li>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Include Text"
                    oncheckedchanged="CheckBox1_CheckedChanged" />
            <asp:TextBox ID="txtMsgBox" runat="server" TextMode="MultiLine"></asp:TextBox>
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
