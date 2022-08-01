<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignRules.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.CaseClient.AssignRules" %>
<%@ Register Src="RuleGrid.ascx" TagName="RuleGrid" TagPrefix="uc1" %>



<div style="margin-left:10px;"> 
    <div style="width:400px;margin-bottom:8px;">
        <span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>
        <br />
    </div>
  <asp:Panel ID="pnPage" runat="server" >  
            <div style="margin-left:0px;margin-top:15px;">
          <asp:Label ID="lblSummary" runat="server" />
          
            <table ID="tblRules" border="0">
                
                 <tr>
                    <td class="codelist" style="width:70px;">
                        Code Type</td>
                    <td> <asp:DropDownList ID="ddlCodeType" runat="server" Width="227px" AutoPostBack="True" OnSelectedIndexChanged="ddlCodeType_SelectedIndexChanged"> </asp:DropDownList></td>
                </tr>
                 <tr>                       
                    <td class="codelist" style="height: 26px">
                        Select Code</td>                    
                    <td style="height: 26px;">
                    <asp:DropDownList ID="ddlCode" runat="server" ></asp:DropDownList>
                        </td>
                     
                </tr>  
               
            </table>       
        </div>  
        
        <uc1:RuleGrid ID="RuleGrid1" runat="server" />


<asp:Button ID="btnAssignRules" CssClass ="btn_floatR btn_save" runat="server" Text="Assign Rules" OnClick="btnAssignRules_Click" />
</asp:Panel>
</div>