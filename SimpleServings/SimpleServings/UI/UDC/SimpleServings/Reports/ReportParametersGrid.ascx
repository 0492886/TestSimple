<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportParametersGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Reports.ReportParametersGrid" %>


<span class="hidden_msg"><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel ID="pnPage" runat="server" style="margin:10px;">

    <asp:Panel runat="server" ID="rptMenuMonthlyCalendar" class="w300">
        <div class="dataLabel">Contract ID</div>
        <div class="dataInput" style="margin-bottom:5px;">
         <asp:DropDownList runat="server" ID="ddlContractID" OnSelectedIndexChanged="ddlContractID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>

        <div class="dataLabel">Year Month (YYYY-MM)</div> 
        
        <div class="dataInput" style="margin-bottom:5px;">
        <asp:TextBox runat="server" ID="tbDate" MaxLength="7" OnTextChanged="tbDate_TextChanged" AutoPostBack="true"></asp:TextBox>
        </div>
            
        <div class="dataLabel">Meal Type</div> 
        <div class="dataInput" style="margin-bottom:5px;">
        <asp:DropDownList runat="server" ID="ddlMealType" AutoPostBack="true" OnSelectedIndexChanged="ddlMealType_SelectedIndexChanged"></asp:DropDownList>
        </div>
        
        <div class="dataLabel">Menu ID</div> 
        
        <div class="dataInput" style="margin-bottom:5px; display:none;"> <%--This drop down is not used in the report anymore.--%>
            <asp:DropDownList runat="server" ID="ddlMenuID" AutoPostBack="true" Visible="false"></asp:DropDownList>
        </div>
        <div style="width:600px; max-height:200px; overflow:auto; border:1px solid lightgray;">
            <asp:CheckBoxList runat="server" ID="cbMenuList" AutoPostBack="true" OnSelectedIndexChanged="cbMenuList_SelectedIndexChanged" RepeatDirection="Vertical"></asp:CheckBoxList>
        </div>

    </asp:Panel>
 

</asp:Panel>