<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SimpleServings.UI.testPage.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <script>
    function open_win()
    {
        window.open("http://www.w3schools.com")
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div   ondblclick="open_win()">Open Window</div>
    </div>
    </form>
</body>
</html>
