<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStaffDetails.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Staff.ViewStaffDetails" %>

<%@ Register Src="../../../UDC/SimpleServings/Staff/ViewStaffDetails.ascx" TagName="ViewStaffDetails"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>

</head>
<body>
    <form ID="form1" runat="server">
    <div>
         
         <uc1:ViewStaffDetails ID="ViewStaffDetails1" runat="server">
        </uc1:ViewStaffDetails>
        </div>
    </form>
</body>
</html>
