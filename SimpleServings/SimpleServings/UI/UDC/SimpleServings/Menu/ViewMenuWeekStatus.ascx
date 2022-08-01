<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewMenuWeekStatus.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.ViewMenuWeekStatus" %>

<script type="text/javascript">
    $(function () {
        var n = $("span.menuStatus:contains('Not Complete')");        
        if (n) {
            $(n).removeClass("Complete").addClass("notComplete");
        }
        else {
            //do nothing
        }

    });
     
</script>

<asp:DataList CssClass="weekStatus" ID="dlMenuWeekStatus" runat="server" RepeatColumns="6">
    <ItemTemplate>
        <asp:Label ID="lblWeekName" CssClass="weekName" runat="server" Text='<%# Eval("WeekInCycleName") %>'></asp:Label>
        <asp:Label ID="lblStatus" CssClass="menuStatus Complete" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
        <br />
    </ItemTemplate>
</asp:DataList>