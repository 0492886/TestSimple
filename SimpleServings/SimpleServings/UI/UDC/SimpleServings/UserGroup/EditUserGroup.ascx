<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditUserGroup.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.UserGroup.EditUserGroup" %>
<%@ Register Src="~/UI/UDC/Navigation/SideBar.ascx" TagName="LinkRepeater" TagPrefix="uc2" %>
<%@ Register Src="~/UI/UDC/SimpleServings/UserGroup/ModulePermissionsList.ascx" TagName="ModulePermissionsList" TagPrefix="uc1" %>

 



<asp:Panel ID="pnPage" CssClass="contentBox"  runat="server">
<div class="title2 h2Size">Edit User Group
<asp:LinkButton ID="btnBackToList" runat="server" CssClass="back floatR"  OnClick="btnBackToList_Click" >Back to List</asp:LinkButton>
</div>

    <div id="divAddAddress" class="dataList"  runat="server">
    <asp:Label ID="lblMsg" runat="server" />  
        <asp:Label ID="lblUserGroupID" runat="server" Visible="false" /> 
        
        
         <div class="dataRow">
                    <div class="dataLabel">User Group Name <em class="requireStyle">*</em> </div>                    
                     <div class="dataInput">
                       <asp:TextBox ID="txtUserGroupName" Width="325px" runat="server"/>              
                      </div>
         </div>
        
                 <div class="dataRow">
                    <div class="dataLabel">Access Level <em class="requireStyle">*</em>   </div>                    
                     <div class="dataInput">
                       <asp:DropDownList Width="325px" ID="ddlAccessLevel" runat="server" />            
                      </div>
         </div>
         <div class="clearfix"></div>   
                  <div class="dataRow">
                    <div class="dataLabel">Group Description</div>                    
                     <div class="dataInput">
                       <asp:TextBox ID="txtComments" runat="server" Height="98px" TextMode="MultiLine" Width="325px" />               
                      </div>
         </div>

                  <div class="dataRow">
                    <div class="dataLabel">Created By</div>                    
                     <div class="dataInput">
                        <asp:Label ID="lblCreatedByText" runat="server" /><asp:Label ID="lblCreatedBy" runat="server" Visible="False" />              
                      </div>
         </div>
        </div>
    <uc1:ModulePermissionsList ID="GroupPermissions" runat="server" ShowSaveButton="false" />
 <h2 class="title2">Links Allowed to view</h2>
    <div class="dataList">
    <div class="dataRow">   
        <div class="viewlink">
            <uc2:LinkRepeater ID="LinkRepeater" runat="server" />
        </div>
    </div>
    </div>

<asp:Button  CssClass="btn btn_save"  ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click" />
 

   <div class="clearfix"></div>   
</asp:Panel>


