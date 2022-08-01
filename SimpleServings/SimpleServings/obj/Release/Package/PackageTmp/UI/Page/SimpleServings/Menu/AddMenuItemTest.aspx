<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenuItemTest.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.AddMenuItemTest" %>


<%@ Register TagPrefix="uc1" TagName="header" Src="~/UI/UDC/Navigation/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="~/UI/UDC/Navigation/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DragMenuItems" src="~/UI/UDC/SimpleServings/Menu/DragMenuItems.ascx" %>

<%--
<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
    Add Menu Items
        <uc1:DragMenuItems ID="DragMenuItems1" runat="server" />
    </form>
</asp:Content>
--%>


<!DOCTYPE HTML>
<html>
    <head id="Head1" runat="server">
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title>Simple Servings</title>

        <!-- CSS -->
        <link href="../../../CSS/jquery.mCustomScrollbar.css" rel="stylesheet" type="text/css" />
        <link rel="stylesheet" href="../../../CSS/jquery-ui.css" />
        <link href="../../../CSS/ModalPopup.css" rel="stylesheet" type="text/css" />
		<link rel="stylesheet" type="text/css" href="../../../CSS/style.css" /> 

    </head>

    <body id="top">
        <div class="menuContainer">

            <!-- Header -->
            <uc1:header ID="header" runat="server" />
            <!-- header end -->

            <!-- Content -->
            <h1 class="titanictitle">Menu</h1>
            <form id="form1" runat="server">
            
             <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <asp:Label ID="lblMenuID" runat="server" Visible="false" />
                <div>
                    <asp:hiddenfield ID="MenuItemsId" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="WeekNumber" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row1Col1" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row1Col2" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row1Col3" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row1Col4" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row1Col5" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row1Col6" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row1Col7" runat="server"></asp:hiddenfield>

                    <asp:hiddenfield ID="Row2Col1" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row2Col2" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row2Col3" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row2Col4" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row2Col5" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row2Col6" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row2Col7" runat="server"></asp:hiddenfield>

                    <asp:hiddenfield ID="Row3Col1" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row3Col2" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row3Col3" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row3Col4" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row3Col5" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row3Col6" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row3Col7" runat="server"></asp:hiddenfield>

                    <asp:hiddenfield ID="Row4Col1" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row4Col2" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row4Col3" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row4Col4" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row4Col5" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row4Col6" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row4Col7" runat="server"></asp:hiddenfield>

                    <asp:hiddenfield ID="Row5Col1" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row5Col2" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row5Col3" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row5Col4" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row5Col5" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row5Col6" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row5Col7" runat="server"></asp:hiddenfield>

                    <asp:hiddenfield ID="Row6Col1" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row6Col2" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row6Col3" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row6Col4" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row6Col5" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row6Col6" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row6Col7" runat="server"></asp:hiddenfield>

                    <asp:hiddenfield ID="Row7Col1" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row7Col2" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row7Col3" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row7Col4" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row7Col5" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row7Col6" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row7Col7" runat="server"></asp:hiddenfield>

                    <asp:hiddenfield ID="Row8Col1" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row8Col2" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row8Col3" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row8Col4" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row8Col5" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row8Col6" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row8Col7" runat="server"></asp:hiddenfield>

                    <asp:hiddenfield ID="Row9Col1" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row9Col2" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row9Col3" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row9Col4" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row9Col5" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row9Col6" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row9Col7" runat="server"></asp:hiddenfield>

                    <asp:hiddenfield ID="Row10Col1" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row10Col2" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row10Col3" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row10Col4" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row10Col5" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row10Col6" runat="server"></asp:hiddenfield>
                    <asp:hiddenfield ID="Row10Col7" runat="server"></asp:hiddenfield>

                     
                     
                    <asp:ScriptManager ID="ScriptManager1" runat="server" >
                    <Services>
                     <asp:ServiceReference Path="~/UI/Page/AsynchronousSave.asmx" />                   
                     </Services>                    
                    </asp:ScriptManager>  
                     <div id="Preview"> </div>  
                     <div class="clearfix"></div>                  
                    <uc1:DragMenuItems ID="DragMenuItems1" runat="server" ShowValidation="false" />
                   
                <asp:Button ID="Button1" runat="server" CssClass="btn_save btn" Text="Save" onclick="Button1_Click" />               
                <div class="clearfix"></div>
            </div>
            
            </form>
            <!-- Content end -->
            
            <!-- Footer -->
		    <uc1:footer ID="footer" runat="server" />
            <!-- Footer end-->
        </div>


        <script src="../../../js/jquery-1.9.1.js"></script>
        <script src="../../../js/jquery-ui.js"></script>
        <script src="../../../js/jquery.mCustomScrollbar.concat.min.js" type="text/javascript"></script>
        <script src="../../../js/customtest.js" type="text/javascript"></script>
	</body>
</html>



