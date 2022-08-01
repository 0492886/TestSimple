<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RemoveUserGroup.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.UserGroup.RemoveUserGroup" %>

<asp:LinkButton ID="btnBackToList" runat="server" class="linksright lnkBackStyle hide" OnClick="btnBackToList_Click" >Back to List</asp:LinkButton>
<asp:LinkButton ID="btnUserList" runat="server" class="linksright lnkBackStyle hide" OnClick="btnUserList_Click" >Go to UserList</asp:LinkButton>



<asp:Panel CssClass="contentBox" ID="pnPage" runat="server">
<div class="title2 h2Size">Remove User Group<a class="back floatR" href="JavaScript:history.back();">Back</a></div>  
   <div class="dataList">
    
    <asp:Label ID="lblMsg" runat="server" />

  <div class="dataRow">                               
                     <div class="dataInput">
<div class="bold marginBottom">
<div class="SectionBarTitle curvedTop"> Selected Group Name: <asp:Label ID="lblGroupName" runat="server" /></div>	
<asp:Label ID="lblUserGroupID" runat="server" Visible="false" /> 
</div>               
           <asp:Label ID="lblMsgRemove" runat="server" CssClass="lblRemoveOrWarnMsg" />
          
           
           <asp:Button CssClass="btn" ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Yes" Visible="False" />
     
           <asp:Button CssClass="btn" ID="btnCancel" runat="server" OnClick="btnBackToList_Click" Text="No" Visible="False" />

   </div> 
   </div>
   </div>   
       </asp:Panel>
      
       
      