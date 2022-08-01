<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="SimpleServings.UI.Page.contact" MasterPageFile="~/UI/Page/dashboardmain.Master" %>
<%@ Register src="../UDC/SimpleServings/Setting/DFTAContactList.ascx" tagname="DFTAContactList" tagprefix="uc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">

        <h1 class="titanictitle">Contact</h1>

        <div class="contentBox">
            <div class="title2 h2Size">Contact Us</div>
                <uc1:DFTAContactList ID="DFTAContactList1" runat="server" />

                    <%--<table class="pure-table pure-table-bordered">
    <thead>
        <tr>
          
            <th>Name</th>
            <th>Title</th>
            <th>Email</th>
        </tr>
    </thead>
    <tbody>
<tr><td>Elysa Dinzes</td> 	<td>Director of Nutrition</td> 	<td><a href="mailto:esilbersmith-dinzes@aging.nyc.gov">esilbersmith-dinzes@aging.nyc.gov</a></td></tr>
<tr><td>Manuela Albuja-Donoso</td> 	<td>Nutrition Supervisor</td> 	<td><a href="mailto:malbujad@aging.nyc.gov">malbujad@aging.nyc.gov</a></td></tr>
<tr><td>Danielle Gill</td> 	<td>Nutrition Supervisor</td> 	<td><a href="mailto:dagill@aging.nyc.gov">dagill@aging.nyc.gov</a></td></tr>
<tr><td>Dana Amaya</td> 	<td>Nutrition Consultant</td> 	<td><a href="mailto:damaya@aging.nyc.gov">damaya@aging.nyc.gov</a></td></tr>
<tr><td>Cheryl Campbell</td> 	<td>Nutrition Consultant</td> 	<td><a href="mailto:ccampbel@aging.nyc.gov">ccampbel@aging.nyc.gov</a></td></tr>
<tr><td>Wakima Keesee</td> 	<td>Nutrition Consultant</td> 	<td><a href="mailto:wkeesee@aging.nyc.gov">wkeesee@aging.nyc.gov</a></td></tr>
<tr><td>Ruth McFarlane</td> 	<td>Nutrition Consultant</td> 	<td><a href="mailto:rmcfarla@aging.nyc.gov">rmcfarla@aging.nyc.gov</a></td></tr>
<tr><td>Cassidel Plummer</td> 	<td>Nutrition Consultant</td> 	<td><a href="mailto:cplummer@aging.nyc.gov">cplummer@aging.nyc.gov</a></td></tr>
<tr><td>Elvera Sherifova</td> 	<td>Nutrition Consultant</td> 	<td><a href="mailto:esherifova@aging.nyc.gov">esherifova@aging.nyc.gov</a></td></tr>
<tr><td>Evalina Spencer</td> 	<td>Nutrition Consultant</td> 	<td><a href="mailto:espencer@aging.nyc.gov">espencer@aging.nyc.gov</a></td></tr>
<tr><td>Joycelyn Valentine</td> 	<td>Nutrition Consultant</td> 	<td><a href="mailto:jvalenti@aging.nyc.gov">jvalenti@aging.nyc.gov</a></td></tr>
<tr><td>Eleni Limperopoulos</td> 	<td>Management Information Systems (MIS)</td> 	<td><a href="mailto:elimperopoulos@aging.nyc.gov">elimperopoulos@aging.nyc.gov</a></td></tr>
</tbody>
</table>--%>

    <%--old contacts--%>
    <%--<tr><td>Adriane Ackroyd</td> 	<td>Nutrition Consultant</td> 	<td><a href="mailto:aackroyd@aging.nyc.gov">aackroyd@aging.nyc.gov</a></td></tr>--%>
    <%--<tr><td>Carmelita Harry</td> 	<td>Principle Nutrition Consultant</td> 	<td><a href="mailto:charry@aging.nyc.gov">charry@aging.nyc.gov</a></td></tr>--%>
    <%--<tr><td>Sylvia Scott</td> 	<td>Nutrition Consultant</td> 	<td><a href="mailto:sscott@aging.nyc.gov">sscott@aging.nyc.gov</a></td></tr>--%>

        </div>
    </form>

    <%--<script type="text/javascript" src="../js/custom2.js"></script>--%>
    <script type="text/javascript" src="../js/jquery-1.9.1.js"></script>
    <%--<script type="text/javascript" src="../../Scripts/tableDnD.js"></script>--%>
    <script type="text/javascript" language="javascript">
        function Validate(x, y) {;
            if (y.Value == "[Select]") {
                y.IsValid = false;
            }

        }
        //$('.tableStyle tbody').sortable().disableSelection();
        //var init = function () {
        //    var tables = $('.tableStyle');
        //    var tableDropFunc = function (table, row) {

        //        var tableParent = $(table).parents("span");
        //        var hiddenOrder = tableParent.find("[id*=\"_hiddenOrder\"]");
        //        hiddenOrder.val($.tableDnD.serialize());

        //    };

        //    for (var j = 0; j < tables.length; j++) {
        //        var rows = $(tables[j]).find("tr");

        //        $(tables[j]).parents("span").find("[id*=\"_hiddenOrder\"]").val("");
        //        //skip header row
        //        for (var i = 0; i < rows.length; i++) {
        //            if (i == 0) {
        //                $(rows[i]).css("background", "none");
        //                $(rows[i]).addClass("nodrop");
        //                $(rows[i]).addClass("nodrag");
        //            }
        //            $(rows[i]).prop("id", i);
        //        }

        //        $(tables[j]).tableDnD({
        //            onDrop: tableDropFunc
        //        });
        //    }
        //}
        //init();
        //onDrop: init();
        //$("body").resize(init);

    </script>
</asp:Content>
