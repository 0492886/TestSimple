<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgressNoteList.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.ProgressNote.ProgressNoteList" %>

<%@ Register Src="../../../UDC/SimpleServings/ProgressNote/ProgressNoteList.ascx" TagName="ProgressNoteList"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Case Note list</title>
</head>
<body>
    <form ID="form1" runat="server">
    <div>
        <uc1:ProgressNoteList ID="ProgressNoteList1" runat="server" />
    
    </div>
    </form>
</body>
</html>
