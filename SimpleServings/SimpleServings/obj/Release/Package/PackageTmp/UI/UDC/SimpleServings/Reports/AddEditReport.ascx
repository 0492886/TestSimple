<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditReport.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Reports.AddEditReport" %>


<span class="hidden_msg"><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel CssClass="dataList" ID="pnPage" runat="server">
<div class="contentBox">
<div class="title2 h2Size">Add/Edit Report<a class="back floatR" href="JavaScript:history.back();">Back</a>
</div>
<div class="dataList">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
        <div class="dataRow">
                    <div class="dataLabel">Report Type :  <asp:DropDownList CssClass="dataInput" ID="ddReportType" runat="server">
</asp:DropDownList></div>                   
                  
                </div>
<div class="clearfix"></div>
        <div class="dataRow w300">
                    <div class="dataLabel">Report Name : </div>                    
                   <div class="dataInput"><asp:TextBox ID="txtReportName" runat="server" ></asp:TextBox></div>                   
                </div>
<div class="clearfix"></div>
        <div class="dataRow w300">
                    <div class="dataLabel">Report Link : </div>                    
                   <div class="dataInput"><asp:TextBox ID="txtReportLink" runat="server" ></asp:TextBox></div>                   
                </div>
<div class="clearfix"></div>
        <div class="dataRow w300">
                    <div class="dataLabel">Report description : </div>                    
                  <div class="dataInput"> <asp:TextBox ID="txtReportdescription" CssClass="w763 noteBox" TextMode="MultiLine" runat="server" ></asp:TextBox></div>                  
                </div>
<div class="clearfix"></div>
<div class="dataRow">
                    <div class="dataLabel">Report Category :  <asp:DropDownList CssClass="dataInput" ID="ddlReportCategory" runat="server">
</asp:DropDownList></div>                   
                  
                </div>
<div class="clearfix"></div>

<br /><br />
</div>
<h2 class="title2">User Groups to include</h2>
<div class="dataList">
 <asp:LinkButton  CssClass="linkBtn" ID="lnkBtnSelectAll" runat="server" onclick="lnkBtnSelectAll_Click" >Select All</asp:LinkButton> |
 <asp:LinkButton  CssClass="linkBtn" ID="lnkBtnDeselectAll" runat="server" EnableViewState="true" onclick="lnkBtnDeselectAll_Click" >Deselect All</asp:LinkButton>
<div class="ViewPageContainer curved">
<asp:CheckBoxList   ID="cblUserGroup" CssClass="checkSpace" runat="server" RepeatColumns="8" RepeatDirection="Horizontal">
</asp:CheckBoxList></div>
</div>

    <asp:Button ID="btnSubmit" runat="server" cssClass="btn btn_save" Text="Submit" 
        onclick="btnSubmit_Click"/>
    </div>
</asp:Panel>