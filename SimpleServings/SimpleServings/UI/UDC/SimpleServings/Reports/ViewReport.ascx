<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewReport.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Reports.ViewReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Src="~/UI/UDC/SimpleServings/Reports/ReportParametersGrid.ascx" tagname="ReportParametersGrid" tagprefix="uc1"  %>
<%@ Register Src="~/UI/UDC/SimpleServings/Reports/ucDailyMenuParameter.ascx" tagname="ucDailyMenuParameter" tagprefix="uc10"  %>
<%@ Register Src="~/UI/UDC/SimpleServings/Reports/ucNutritionFactLabelsDailyParameter.ascx" Tagname="ucNutritionFactLabelsDailyParameter" Tagprefix="uc11"%>
<%@ Register Src="~/UI/UDC/SimpleServings/Reports/ucCountMenusWithCycleIdByRecipeIDParameter.ascx" TagName="ucCountMenusWithCycleIdByRecipeIDParameter" TagPrefix="uc22"%>

<span class="hidden_msg"><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></span>
<div class="themetitle2">
    <div class="themetitlewrapper">
        <h1 class="titanictitle">View Report</h1>
    </div>
</div>
<asp:Panel CssClass="dataList" ID="pnPage" runat="server">




<div class="contentBox" style="min-height:800px;">
<div class="title2 h2Size"> <asp:Label runat="server" id="lblReportName"></asp:Label></div>

<uc1:ReportParametersGrid runat="Server" id="uc1ReportParameter" Visible="false"/>
<uc10:ucDailyMenuParameter runat="server" ID="ucDailyMenuParameter" Visible="false" />
<uc11:ucNutritionFactLabelsDailyParameter runat="server" ID="ucNutritionFactLabelsDailyParameter" Visible="false" />
<uc22:ucCountMenusWithCycleIdByRecipeIDParameter runat="server" ID="ucCountMenusWithCycleIdByRecipeIDParameter" Visible="false" />

<div runat="server" id="divreportID6" visible="false">


<div class="dataList">
    <div class="dataRow">

            <div class="dataLabel">Menu ID :</div>

            <div class="dataInput"> 
                <asp:TextBox runat="server" style="float:left; width: 150px;" ID="tbMenuID" ></asp:TextBox>
                
            </div>

    </div>
    <div class="dataRow">
        
    </div>
</div>
</div>

<div class="clearfix"></div>
<%--<div class="dataRow">--%>
<asp:Button ID="btnSearch" CssClass="btn btn_save" style="float:left; margin-left:5px; height:25px;" runat="server" Text="View Report" OnClick="btnSearch_Click"/>
<%--    </div>--%>
<div class="clearfix"></div>  
<br />
<br />


<asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"></asp:ScriptManager>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" ShowPrintButton="true" Height="100%" Visible="false" ShowParameterPrompts="false" Font-Names="Verdana" Font-Size="8pt" 
ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" style="width:800px; margin:20px;"></rsweb:ReportViewer>

</div>


</asp:Panel>