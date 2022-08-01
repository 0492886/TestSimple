<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewStaffDetails.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.ViewStaffDetails" %>
<%@ Register Src="ViewModulePermissions.ascx" TagName="ViewModulePermissions" TagPrefix="uc4" %>
<%@ Register Src="ViewComments.ascx" TagName="ViewComments" TagPrefix="uc3" %>
<%@ Register Src="ViewGeneralInfo.ascx" TagName="ViewGeneralInfo" TagPrefix="uc1" %>
<%@ Register Src="ViewAccountInfo.ascx" TagName="ViewAccountInfo" TagPrefix="uc2" %>

<%@ Register src="ViewStaffAccessLevel.ascx" tagname="ViewStaffAccessLevel" tagprefix="uc5" %>

         <div  ID="divStaff" runat="server" class="contentBox">                  
        <div class="title2 h2Size">General Information
        <a href="JavaScript:history.back();" class= "back floatR">Back</a>
            
        <asp:LinkButton ID="lnkBDeactivateStaff" runat="server" CssClass="check floatR" Text="Deactivate Staff member" OnClick="lnkBDeactivateStaff_Click" />
        <asp:LinkButton ID="lnkBLockStaff" runat="server" OnClientClick="return confirm('Lock the account?');" CssClass="check floatR" Text="Lock Staff account" OnClick="lnkBLockStaff_Click"/>
        <asp:HyperLink CssClass="edit floatR" ID="hlEditGeneralInfo" runat="server"  Text="Edit General Info" />	
        <asp:LinkButton ID="lnkBActivateStaff" runat="server" CssClass="add floatR" Text="Activate Staff member" OnClick="lnkBActivateStaff_Click" />	
        <asp:LinkButton ID="lnkBUnlockStaff" runat="server" OnClientClick="return confirm('Unlock the account?');" CssClass="add floatR" Text="Unlock Staff account" OnClick="lnkBUnlockStaff_Click" />
        <asp:LinkButton ID="lnkBackToList" runat="server" CssClass= "hide btn_text btn_add floatR" Text="Back to List" OnClick="lnkBackToList_Click"  />
                      </div>

    <div class="dataList">
         <div class="dataRow">                                 
                     <div class="dataInput">
                      <uc1:ViewGeneralInfo ID="ViewGeneralInfo1" runat="server" />                     
                      </div>
                     
         </div>          
         </div>
    <div class="title2 h2Size">Account Information   <asp:HyperLink CssClass="edit floatR" ID="hlEditAccountInfo" runat="server"  Text="Edit Account Info" />    </div>
    <div class="dataList">
         <div class="dataRow">     
                     <div class="dataInput">
                     <uc2:ViewAccountInfo ID="ViewAccountInfo1" runat="server" />                     
                      </div>
                </div>
   </div>

   <div class="title2 h2Size">Module Permissions <asp:HyperLink CssClass="edit floatR" ID="hlEditModulePermissions" runat="server"  Text="Edit Module Permissions" /> </div>
   <div class="dataList">
         <div class="dataRow">        
                     <div class="dataInput">
                      <uc4:ViewModulePermissions ID="ViewModulePermissions1" runat="server" ShowEditCols="false" />                     
                      </div>
          </div>
  </div>

     <div class="title2 h2Size">Access level<asp:HyperLink CssClass="edit floatR" ID="hlEditStaffAccessLevel" runat="server"  Text="Edit Access Level" /></div>
     <div class="dataList">
          <div class="dataRow">       
                     <div class="dataInput">
                     <uc5:ViewStaffAccessLevel ID="ViewStaffAccessLevel1" runat="server" />                     
                      </div>
          </div>
          </div>
     <div class="title2 h2Size">Comments<asp:HyperLink CssClass="add floatR" ID="hlAddComments" runat="server"  Text="Add Comments" />     </div>
     <div class="dataList">
          <div class="dataRow">  
                     <div class="dataInput">
                     <uc3:ViewComments ID="ViewComments1" runat="server" />
                     <asp:Label ID="lblStaffID" runat="server" Visible="False" />                     
                      </div>
         </div>
         </div>
       
    
   </div>  
       <div class="clearfix"></div>