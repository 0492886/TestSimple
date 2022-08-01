<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewAllRules.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.ViewAllRules" %>
<%@ Register Src="RuleGrid.ascx" TagName="RuleGrid" TagPrefix="uc1" %>
 <span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>


    
<asp:Panel  CssClass="contentBox" ID="pnPage" runat="server">
<div class="title2 h2Size">View All Rules
</div>
<div class="dataList">
        <div class="SectionTitle"><asp:CheckBox ID="cbDeactiveRules" runat="server" Text ="&nbsp;Show Deactivated" AutoPostBack="true" OnCheckedChanged="cbDeactiveRules_CheckedChanged" />
        </div>
        <uc1:RuleGrid ID="RuleGrid1" runat="server" />
</div>
   

   <div class="clearfix"></div>   
</asp:Panel>