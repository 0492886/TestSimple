<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCountMenusWithCycleIdByRecipeIDParameter.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Reports.ucCountMenusWithCycleIdByRecipeIDParameter" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<span class="hidden_msg"><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel ID="pnPage" runat="server" style="margin:10px;">

    <asp:Panel runat="server" ID="rptCountMenus" class="w300">
        <div class="dataLabel">Recipe ID</div>
        <div class="dataInput" style="margin-bottom:5px;">
         <asp:DropDownList runat="server" ID="ddlRecipeID" OnSelectedIndexChanged="ddlRecipeID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>

              
        <div class="dataLabel">Recipe View</div> 
        <div class="dataInput" style="margin-bottom:5px;"> 
            <asp:DropDownList runat="server" ID="ddlRecipeView" OnSelectedIndexChanged="ddlRecipeView_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>

        <div class="dataLabel">Cycle ID</div> 
        <div class="dataInput" style="margin-bottom:5px;"> 
            <asp:DropDownList runat="server" ID="ddlCycleID" AutoPostBack="true"></asp:DropDownList>
        </div>
        

        <div runat="server" id="divStartDate">
            <div id="Div1" class="dataLabel" runat="server">Start Date (MM-DD-YYYY)</div> 
            <div class="dataInput" style="margin-bottom:5px;">
                <asp:TextBox runat="server" ID="tbStartDate"></asp:TextBox>
                <ajaxToolkit:CalendarExtender runat="server" ID="ajaxCalender1" TargetControlID="tbStartDate"></ajaxToolkit:CalendarExtender>
            </div>
        </div>


      <div runat="server" id="divEndDate">
            <div id="Div3" class="dataLabel" runat="server">End Date (MM-DD-YYYY)</div> 
            <div class="dataInput" style="margin-bottom:5px;">
                <asp:TextBox runat="server" ID="tbEndDate"></asp:TextBox>
                <ajaxToolkit:CalendarExtender runat="server" ID="ajaxCalender2" TargetControlID="tbEndDate"></ajaxToolkit:CalendarExtender>
            </div>
        </div>
    </asp:Panel>
 

</asp:Panel>