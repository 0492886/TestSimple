<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SimpleServings.UI.testPage.home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="../../UI/js/jquery-1.7.2.min.js"></script>	

    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnPost").click(function () {
                var $form = $(form1);

                AddParameter($form, "juid", $("#txtUserName").val());

                $form[0].submit();
            });
        });

        function AddParameter(form, name, value) {
            var $input = $("<input />").attr("type", "hidden")
                                    .attr("name", name)
                                    .attr("value", value);
            form.append($input);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server" action="/SimpleServings/UI/Page/Home.aspx" method="post">
    <div>
        UserName:&nbsp;<input type="text" id="txtUserName" style="width: 150px;" />
        &nbsp;&nbsp;&nbsp;&nbsp;<button id="btnPost" name="btnPost" type="button">Test Juniper Login</button>
    </div>
    </form>
</body>
</html>
