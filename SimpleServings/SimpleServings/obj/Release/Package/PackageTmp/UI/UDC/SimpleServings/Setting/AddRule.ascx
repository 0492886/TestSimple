<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddRule.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.CaseClient.AddRule" %>


 
<asp:Panel  CssClass="contentBox" ID="pnPage" runat="server">

<div class="title2 h2Size">Add Rule

</div>

<div class="dataList">
 <span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Label ID="lblSummary" runat="server" Font-Bold="True" Visible="False"></asp:Label>
                <div class="dataRow">
                    <div class="dataLabel">Rule Description :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtRuleDescription" runat="server" Width="200px"></asp:TextBox>                     
                      </div>
                </div>

                 <div class="dataRow">
                    <div class="dataLabel">Custom Error Message :</div>                    
                     <div class="dataInput">
                      <asp:TextBox ID="txtCustomMessage" runat="server" Width="200px"></asp:TextBox>                     
                      </div>
                </div>

                 <div class="dataRow">                                       
                     <div class="dataInput">
                     <asp:CheckBox  SkinID="ChkBoxStyle" ID="cbStaffSpecific" runat="server" /><label class="control-label">&nbsp;Please Check if Rule is Staff Specific</label> 
                     </div>
                </div>

                 <div class="dataRow">
                    <div class="dataLabel">SQL Statement :</div>                    
                     <div class="dataInput">
                      <asp:TextBox ID="txtSqlStatement" runat="server" TextMode="MultiLine" Height="120" Width="400px"></asp:TextBox>                     
                      </div>
                </div>


</div>

<asp:Button CssClass="btn btn_save" ID="btnAddRule" runat="server" Text="Save Rule" OnClick="btnAddRule_Click" /><br />

   <div class="clearfix"></div>   
</asp:Panel>