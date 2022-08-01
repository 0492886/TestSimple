<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddStaffAccessLevel.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.AddStaffAccessLevel" %>

<%@ Register src="ContractGrid.ascx" tagname="ContractGrid" tagprefix="uc1" %>

<%@ Register src="ViewModulePermissions.ascx" tagname="ViewModulePermissions" tagprefix="uc2" %>


<asp:Label ID="lblStaffID" runat="server" Visible="False" />
<asp:Label ID="lblMsg" runat="server"  />
<asp:Panel CssClass="contentBox" ID="pnPage" runat="server" >
 <div class="title2 h2Size">Staff Access Level
       <asp:HyperLink ID="hlGoBack" CssClass="back floatR" runat="server" Text="Back" /> 
 </div>

<div class="dataList">

              <div class="dataRow">
                    <div class="dataLabel"><span class="wtitleSmall">Staff Name : </span><asp:Label CssClass="dataInput" ID="lblSatffName" runat="server" />   </div>  
                </div>


                 <div class="dataRow">
                    <div class="dataLabel"><span class="wtitleSmall">User Group : </span><asp:DropDownList CssClass="dataInput" ID="ddlUserGroupName" runat="server" AutoPostBack="true" 
        onselectedindexchanged="ddlUserGroupName_SelectedIndexChanged" /></div>  
                </div>
              
                <div class="dataRow">                            
                     <div class="dataInput">
                    <uc2:ViewModulePermissions ID="ViewModulePermissions1" runat="server" ShowEditCols="false" />                     
                      </div>
                </div>


               <div class="dataRow">
                    <div class="dataLabel">User Group Access Level : <asp:Label  CssClass="dataInput" ID="lblGroupAccessLevel" runat="server" Visible="false"/>
                    <asp:Label  CssClass="dataInput" ID="lblGroupAccessLevelText" runat="server" /></div>   
                </div>
     

     <asp:Panel ID="pnSponsor" runat="server" Visible="false" >
         <div class="dataRow">
                    <div class="dataLabel">Sponsor : <asp:DropDownList CssClass="dataInput" ID="ddlSponsor" runat="server" AutoPostBack="true"
             OnSelectedIndexChanged="ddlSponsor_SelectedIndexChanged" />
             </div>                    
                   
                </div>
    </asp:Panel>

    <asp:Panel ID="pnCaterer" runat="server" Visible="false" >
         <div class="dataRow">
                    <div class="dataLabel">Caterer :  <asp:DropDownList  CssClass="dataInput" ID="ddlCaterer" runat="server" AutoPostBack="true"
            OnSelectedIndexChanged="ddlCaterer_SelectedIndexChanged" />
            </div>
                </div> 
    </asp:Panel>

    <asp:Panel ID="pnContract" runat="server" Visible="false" >
     <div class="dataRow">
                    <div class="dataLabel">Contracts :  </div>
                    <div class="dataInput">
                     <uc1:ContractGrid ID="ContractGrid1" runat="server" /> 
                    </div>
      </div> 
    </asp:Panel>  
</div>
       

    <asp:Button ID="btnSave" CssClass="btn btn_save" runat="server" Text="Save" onclick="btnSave_Click"/>

</asp:Panel>