<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNutritionFactLabelsDailyParameter.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Reports.ucNutritionFactLabelsDailyParameter" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<span class="hidden_msg"><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel ID="pnPage" runat="server" style="margin:10px;" class="w300">

<div class="dataRow">
    <div class="dataLabel">Menu ID :</div>
    <div class="dataInput"> 
        <asp:TextBox runat="server" style="float:left;" ID="tbMenuID" ></asp:TextBox>
    </div>
</div>
    <div class="clearfix"></div>
<div class="dataRow">
<div class="dataLabel">Year Month (MM-DD-YYYY)</div>
    <div class="dataInput" style="margin-bottom:5px;">
        <asp:TextBox runat="server" ID="tbDate"></asp:TextBox>
        <ajaxToolkit:CalendarExtender runat="server" ID="ajaxCalender" TargetControlID="tbDate"></ajaxToolkit:CalendarExtender>
    </div>
</div>
</asp:Panel>