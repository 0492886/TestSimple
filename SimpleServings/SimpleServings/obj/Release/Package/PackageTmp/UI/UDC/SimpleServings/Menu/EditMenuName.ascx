<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditMenuName.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.EditMenuName" %>
  <asp:Label ID="lblMsg" runat="server"></asp:Label>

<asp:Panel  CssClass="contentBox" ID="pnPage" runat="server">
 <div class="title2 h2Size">Edit Menu
<a class="back floatR" href="JavaScript:history.back();">Back</a>
</div>
<div class="dataList">
           <div class="dataRow">
	      <asp:Label ID="lblMenuID" runat="server" Visible="false" />
            <div class="dataRow w500">
                    <div class="dataLabel">Menu Name :</div>                    
                     <div class="dataInput">                                              
             <asp:TextBox ID="txtMenuName" runat="server"></asp:TextBox>                   
                      </div>
            </div>
          
             </div>

           
           
     </div>                
          <asp:Button ID="btnEditMenuName" CssClass="btn btn_save" runat="server" Text="Save" onclick="btnEditMenuName_Click" />

    <div class="clearfix"></div>  

</asp:Panel>
 








