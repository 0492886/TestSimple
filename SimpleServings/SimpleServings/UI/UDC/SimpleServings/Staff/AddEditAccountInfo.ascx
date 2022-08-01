<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditAccountInfo.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.AddEditAccountInfo" %>

<asp:Label CssClass="msglabel" ID="lblSummary" runat="server" />
   <asp:Panel CssClass="contentBox marginTopFix" ID="pnPage" runat="server" >
<div class="title2 h2Size">Account Information
<a class="back floatR" href="JavaScript:history.back();">Back</a>
</div>
   <div class="dataList">
              <div class="dataRow w500">
                    <div class="dataLabel">User Name :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtUserName" runat="server"/>
                         <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="msglabel" Text="Invalid Username" runat="server" ControlToValidate="txtUserName"
                                    ValidationExpression="^(\w+)$" Display="Dynamic" />--%>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUserName" ErrorMessage=" required" />
                     
                      </div>
                </div>

                    <div class="dataRow w500">
                    <div class="dataLabel">Password :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtPassword"  runat="server" />
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="msglabel" Text="Invalid Password" runat="server" ControlToValidate="txtPassword"
                                    ValidationExpression="^(\w+)$" Display="Dynamic" Enabled="false"  />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Enabled="false"  runat="server" ControlToValidate="txtPassword" ErrorMessage="* required" />
                     </div>
                     <div class="dataInput">
                       <asp:Button CssClass="btn_black2" ID="btnGenerate"  runat="server" CausesValidation="False" OnClick="btnGenerate_Click" Text="Generate Password" Visible="false" /> 
                    
                     </div>
                </div>

                    <div class="dataRow w500">
                    <div class="dataLabel">Confirm Password :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtConfirmPassword"  runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Enabled="false" ControlToValidate="txtConfirmPassword" ErrorMessage="* required" />
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Enabled="false"  ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="passwords do not match" /></div>
                 </div>
               

                  <div class="dataRow w500">
                    <div class="dataLabel">E-mail :</div>                    
                     <div class="dataInput">
                        <asp:TextBox ID="txtEmail" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail" ErrorMessage="* required" />
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="* invalid email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" /></div>
          
                     
                      </div>
              
<%--
                <div class="dataRow w500">
                    <div class="dataLabel">Theme</div>                    
                     <div class="dataInput">
                     <asp:DropDownList ID="ddlTheme" runat="server" Width="154px" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlTheme" ErrorMessage="* required" InitialValue="0" /></div>
                    
                     
                      </div>
                </div>
      --%>     
      </div>   
        <div class="clearfix"></div>
       <asp:Button CssClass="btn btn_save" ID="btnSave" runat="server" OnClientClick="newSession();" OnClick="btnSave_Click" Text="Save" />
     
        <asp:Label ID="lblStaffID" runat="server" Visible="False" />


</asp:Panel>


