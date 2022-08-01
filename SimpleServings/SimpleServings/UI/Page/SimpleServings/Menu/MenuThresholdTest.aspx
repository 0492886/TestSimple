<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuThresholdTest.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.MenuThresholdTest" %>

<%@ Register src="../../../UDC/SimpleServings/Menu/ViewMenuWeekStatus.ascx" tagname="ViewMenuWeekStatus" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        MenuID: <asp:TextBox ID="txtMenuID" runat="server"></asp:TextBox><br />
        Week Cycle: <asp:TextBox ID="txtWeekCycle" runat="server"></asp:TextBox> <br />
        <asp:Button ID="btnValidate" runat="server" Text="Validate" 
            onclick="btnValidate_Click" /><br /><br />

        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
    <div>
        <uc1:ViewMenuWeekStatus ID="ViewMenuWeekStatus1" runat="server" />
    </div>

    <table>
        <tr>
            <td>&#176;</td>
            <td>&deg;</td>
        </tr>
        <tr>
            <td>&#8805;</td>
            <td>&ge;</td>
        </tr>
        <tr>
            <td>&#8804;</td>
            <td>&le;</td>
        </tr>
    </table>
    </form>
</body>
</html>
