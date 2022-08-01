<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDailyMenuParameter.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Reports.ucDailyMenuParameter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<span class="hidden_msg"><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel ID="pnPage" runat="server" style="margin:10px;">

    <asp:Panel runat="server" ID="rptMenuMonthlyCalendar" class="w300">
        <div class="dataLabel">Contract ID</div>
        <div class="dataInput" style="margin-bottom:5px;">
         <asp:DropDownList runat="server" ID="ddlContractID" OnSelectedIndexChanged="ddlContractID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>

              
       

        <div runat="server" id="divYearMonth">
            <div class="dataLabel" runat="server">Year Month (MM-DD-YYYY)</div> 
            <div class="dataInput" style="margin-bottom:5px;">
                <asp:TextBox runat="server" ID="tbDate" OnTextChanged ="tbDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                <ajaxToolkit:CalendarExtender runat="server" ID="ajaxCalender" TargetControlID="tbDate" ></ajaxToolkit:CalendarExtender>
            </div>
        </div>

        <div class="dataLabel">Menu ID</div> 
        <div class="dataInput" style="margin-bottom:5px;"> 
            <asp:DropDownList runat="server" ID="ddlMenuID"  ></asp:DropDownList>
        </div>
        

    </asp:Panel>
 

</asp:Panel>