<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditRule.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.EditRule" %>
<asp:Label ID="lblMsg" runat="server" />
<asp:Panel  CssClass="contentBox" ID="pnPage" runat="server">
<h2 class="title2">Edit Rule</h2>  
            <div class="dataList"> 
<asp:Label ID="lblSummary" runat="server" Font-Bold="True" Visible="False"></asp:Label>

    <asp:Label ID="lblRuleID" runat="server" Visible="False"></asp:Label>

               <div class="dataRow">
                    <div class="dataLabel">Rule Description :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtRuleDescription" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                      </div>
                </div>

                
                <div class="dataRow">
                    <div class="dataLabel">Custom Error Message :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtCustomMessage" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>                     
                      </div>
                </div>

                
                <div class="dataRow">
                                      
                     <div class="dataInput">
                      <div class="dataLabel">&nbsp;Please Check if Rule is Staff Specific <asp:CheckBox ID="cbStaffSpecific" runat="server" /></div>
                      </div>
                </div>

                
                <div class="dataRow">
                    <div class="dataLabel">SQL Statement :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtSqlStatement" runat="server" Height="70px" TextMode="MultiLine" Width="500px"></asp:TextBox>                     
                      </div>
                </div>

                
                <div class="dataRow">
                   <div class="dataLabel">Active</div>                    
                     <div class="dataInput">
                     <asp:CheckBox ID="cbActive" runat="server" />&nbsp; Uncheck to deactivate this rule                     
                      </div>
                </div>    
    
</div>     
<asp:Button ID="btnAddRule" runat="server" Text="Save"  CssClass="btn btn_save" OnClick="btnAddRule_Click" />
  


<div class="clearfix"></div>   
</asp:Panel>