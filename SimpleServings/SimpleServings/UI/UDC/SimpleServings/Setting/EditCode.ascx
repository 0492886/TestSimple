<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCode.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.EditCode" %>
<%@ Register Src="RuleGrid.ascx" TagName="RuleGrid" TagPrefix="uc1" %>

 <span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>

<asp:Panel  CssClass="contentBox"  ID="pnPage" runat="server"> 

      <h2 class="title2">Edit Code</h2>
      <asp:Label CssClass="hide" ID="lblCodeValue" runat="server" Font-Bold="true" />       
      <div ID="divAddAddress" class="ViewPageContainer curved" runat="server">
      <div class="dataList">
      <div class="InformationListing w500">

      <div class="dataRow">
                    <div class="dataLabel">Code Type <em class="requireStyle">*</em> :</div>                     
                     <div class="dataInput">
                    <asp:DropDownList ID="ddlCodeType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCodeType_SelectedIndexChanged" > </asp:DropDownList>
                   
                     </div>
      </div>

       <div class="dataRow">
                    <div class="dataLabel">Code Value <em class="requireStyle">*</em> :</div>                    
           <div class="dataInput">
           <asp:TextBox ID="txtCodeValue" runat="server" ></asp:TextBox> 
           </div>       
      </div>
               
               
               
       <div class="dataRow">
                    <div class="dataLabel">Depends On Type :</div>                     
                     <div class="dataInput">
                     <asp:DropDownList ID="ddlDependsOnType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDependsOnType_SelectedIndexChanged" ></asp:DropDownList>
                     </div>
      </div>

      <div class="dataRow">
                    <div class="dataLabel">Depends On Code :</div>                     
                     <div class="dataInput">
                     <asp:CheckBoxList ID="cbDependsOnCode" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"  OnSelectedIndexChanged="cbDependsOnCode_SelectedIndexChanged" AutoPostBack="true" ></asp:CheckBoxList>
                     </div>
      </div>

      <div class="dataRow">
                    <div class="dataLabel">Comment :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtComment" runat="server" Height="100px" Width="350px" TextMode="MultiLine" ></asp:TextBox>
                     </div>
      </div>
                
               </div> 
               </div>
                   
                <asp:Label ID="lblCreatedBy" runat="server" Visible="False"></asp:Label><br />
                <asp:Label ID="lblDependsOnCodeType" runat="server" Visible="False"></asp:Label>   
                       
                <h2 class="title2">Assign Rules to this Code</h2>
                
              <div class="dataList">  
                <uc1:RuleGrid ID="RuleGrid1" runat="server" />
              </div> 
           
              <asp:Button  CssClass="btn btn_save" ID="btnAddCode"  runat="server" OnClick="btnAddCode_Click" Text="Save" />
         

</div>
   <div class="clearfix"></div>   
</asp:Panel>