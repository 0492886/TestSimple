<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditStaff.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.AddEditStaff" %>
  
    <asp:Label ID="lblHeader" runat="server" />

    <asp:Label ID="lblSummary" runat="server" />
    <asp:Label ID="lblStaffID" runat="server" Visible="False" />
    
    
    
    <div class="SectionTitle hide">Name  <em class="requireStyle requireLoneMsg">*<span>required</span></em></div>
     <div class="contentBox" style="margin-top:10px!important">   
     <div class="title2 h2Size">General Information
<a class="back floatR" href="JavaScript:history.back();">Back</a></div>
     <div class="dataList">
         <div class="dataRow w500">
                    <div class="dataLabel">First Name :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtFirstName" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage=" required" />                     
                      </div>
         </div>

          <div class="dataRow w500">
                    <div class="dataLabel">Last Name :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtLastName" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage=" required" />
                     
                      </div>
          </div>

      </div>
     <h2 class="title2">Work Assignment</h2>
   
     <%--
     <div class="dataRow">
                    <div class="dataLabel">Site</div>                    
                     <div class="dataInput">
                     <asp:DropDownList ID="ddlSiteCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSiteCode_SelectedIndexChanged" />
                    <em class="requireStyle">*</em>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSiteCode" ErrorMessage=" required" InitialValue="0" />                     
                      </div>
      </div>
         --%>
<div class="dataList">
                 <div class="dataRow w500">
                    <div class="dataLabel">Managed By :</div>                    
                     <div class="dataInput">
                     <asp:DropDownList ID="ddlManagedBy" runat="server"/>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlManagedBy" ErrorMessage=" required" InitialValue="1" />                     
                      </div>
                </div>


                 <div class="dataRow w500">
                    <div class="dataLabel">Work Phone <em class="requireStyle">*</em> :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtWorkPhone" runat="server" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtWorkPhone" ErrorMessage=" required"  />                     
                      </div>
                </div>

                 <div class="dataRow w500">
                    <div class="dataLabel">Work Fax :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtFax" runat="server" />                     
                      </div>
                </div>
         </div>

      <h2 class="title2">Personal Information</h2>    
      <div class="dataList">
                <div class="dataRow w500">
                    <div class="dataLabel">Phone :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtHomePhone" runat="server" />                     
                      </div>
                </div>
                <div class="dataRow w500">
                    <div class="dataLabel">Street Address 1 :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtStAddress1" runat="server" />                     
                      </div>
                </div>

                 <div class="dataRow w500">
                    <div class="dataLabel">Street Address 2 :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtStAddress2" runat="server" />                     
                      </div>
                </div>

                 <div class="dataRow w500">
                    <div class="dataLabel">City :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtCity" runat="server" />                     
                      </div>
                </div>

                 <div class="dataRow w500">
                    <div class="dataLabel">State :</div>                    
                     <div class="dataInput">
                     <asp:DropDownList ID="ddState" runat="server" />                     
                      </div>
                </div>

                 <div class="dataRow w500">
                    <div class="dataLabel">Zip Code :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtZipCode" runat="server" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtZipCode" ErrorMessage=" invlid zip code" ValidationExpression="\d{5}(-\d{4})?" />                   
                      </div>
                </div>
                </div>
           <div class="clearfix"></div>
            <asp:Button CssClass="btn btn_save" ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Save" />

 </div>
