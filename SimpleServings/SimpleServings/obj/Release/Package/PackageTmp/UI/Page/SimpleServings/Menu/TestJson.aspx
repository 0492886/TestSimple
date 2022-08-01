<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestJson.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Menu.TestJson" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Json</title>
    <script src="../../../../Scripts/jquery-1.10.1.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>

    
Your Name :
<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
Your ID:
<asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
<input id="Find" type="button" value="Find"
    onclick = "GetInfo()" />
    <br />
 Name: <asp:Label ID="lblLastName" runat="server"></asp:Label>  
 <br />
 ID:
    <asp:Label ID="lblUserID" runat="server"></asp:Label> 
    <br />  
List:
    <asp:Label ID="lblListOfNumbers" runat="server"></asp:Label>   
    <br />
Iterating through items in List:
 <asp:Label ID="lblThird" runat="server"></asp:Label>   
    <br />
    </div>
    </form>
</body>
<script type = "text/javascript">
    function GetInfo() {
        $.ajax({
            type: "POST",
            url: "TestJson.aspx/GetUserInfo",
            data: '{name: "' + $("#<%=txtUserName.ClientID%>")[0].value + '", id: "' + $("#<%=txtUserID.ClientID%>")[0].value + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess           
        });
    }
    function OnSuccess(response) {
        if (response.hasOwnProperty("d"))
            var JSONObject = response.d;
        else
            var JSONObject = response;
        
        document.getElementById("lblLastName").innerHTML = JSONObject.LastName
        document.getElementById("lblUserID").innerHTML = JSONObject.UserID
        var listOfNum = JSONObject.ListOfNumbers;
        document.getElementById("lblListOfNumbers").innerHTML = listOfNum;
        document.getElementById("lblThird").innerHTML = '';
        for (var i = 0; i < listOfNum.length; i++) 
        {
            document.getElementById("lblThird").innerHTML += listOfNum[i] + '&nbsp;';
        }  
    }
</script>
</html>
