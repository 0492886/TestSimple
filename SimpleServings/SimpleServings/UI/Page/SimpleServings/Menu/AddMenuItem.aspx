<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenuItem.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.AddMenuItem" MaintainScrollPositionOnPostback="true" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="~/UI/UDC/Navigation/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DragMenuItems" src="~/UI/UDC/SimpleServings/Menu/DragMenuItems.ascx" %>


<!DOCTYPE HTML>
<html>
<head id="Head1" runat="server">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">--%>
	<title>Simple Servings</title>
     <meta http-equiv="X-UA-Compatible" content="IE=8;IE=Edge;chrome=1;" />
     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- CSS -->
    <link rel="stylesheet" href="../../../CSS/jquery-ui.css" />
    <link href="../../../CSS/ModalPopup.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../../CSS/style.css" />
    <script src="../../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../../js/jquery-ui.js" type="text/javascript"></script>
    <script src="../../../js/custom.js" type="text/javascript"></script>

        <script type="text/javascript">
            var fromSearchBox = false;
            function SetSearchBox(e) {
                if (e.keyCode == 13) {
                    fromSearchBox = true;
                    $("#DragMenuItems1_RecipeSearchList1_btnSearch").click();
                }
            }
    </script>

</head>


<body id="top" oncontextmenu="return false">

    <asp:Label ID="lblpnMsg" runat="server"></asp:Label>


<asp:Panel ID="pnPage" CssClass="menuContentBox" runat="server">
    <div class="menuContainer">
        <!-- Content -->
        <form id="form1" runat="server">
            <div class="title2 h2Size bold orangeGrad"><span class="whiteFont">Menu Builder</span> 
                <asp:Button ID="Button1" runat="server" CssClass="btn_saveMenu btn" OnClientClick="return (!fromSearchBox);" Text="Done" onclick="btnSave_Click" />
            </div>
            <asp:Label ID="lblIsComplete" runat="server" style="display:none" />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <asp:Label ID="lblMenuID" runat="server" Visible="false" />
            <div>
                <asp:hiddenfield ID="menuItemId" runat="server"></asp:hiddenfield>
                <asp:hiddenfield ID="MenuItemsId" runat="server"></asp:hiddenfield>
                <asp:hiddenfield ID="WeekNumber" runat="server"></asp:hiddenfield>
                <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager> 

                <script type="text/javascript">
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_endRequest(EndRequestHandler);
                    function EndRequestHandler(sender, args) {
                        fromSearchBox = false;
                    }
                </script>
                <%-- 
                <div style="line-height:26px; position: absolute; right: 11px; top: 5px;" >
                                 
                <span class="whiteFont bold font11">Too Low</span> <asp:Label ID="lblMeterLow" runat="server" CssClass="nutritionAlertLow" />
                <span class="whiteFont bold font11">Good</span> <asp:Label ID="lblMeterNormal" runat="server" CssClass="nutritionAlertRange" />
                <span class="whiteFont bold font11">Too High</span> <asp:Label ID="lblMeterHigh" runat="server" CssClass="nutritionAlertHigh" />
                </div>
                --%>
                <div style="clear:both; display:block" >
                    <uc1:DragMenuItems ID="DragMenuItems1" runat="server" ShowValidation="false" />
                    <asp:Button ID="btnSave" runat="server" CssClass="btn_save btn" Text="Done" onclick="btnSave_Click" />
                </div>
                <div class="clearfix"></div>
            </div>
            
        </form>
        <!-- Content end -->
            
        <!-- Footer -->
		<uc1:footer ID="footer" runat="server" />
        <!-- Footer end-->
    </div>
  </asp:Panel>  
</body>
</html>

