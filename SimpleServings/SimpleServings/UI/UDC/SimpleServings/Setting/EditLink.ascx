<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditLink.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.EditLink" %>

 
 <asp:Panel ID="pnPage" CssClass="contentBox" runat="server">
           
            <div class="title2 h2Size">Edit Link
            <asp:LinkButton ID="lnkBLinkList"  CssClass="back floatR" runat="server" Text="Back To List" OnClick="lnkBLinkList_Click" />
            </div>   

            <div class="dataList">

                <span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" /></span>



                <asp:Label ID="lblLinkID" runat="server" Visible="false" />
                
                <em class="requireStyle requireLoneMsg">* <span>required</span></em>
                
                <div ID="tblLink">
                
              <div class="dataRow w500">
                    <div class="dataLabel">Type<em class="requireStyle">*</em>:</div>                    
                     <div class="dataInput">
                    <asp:DropDownList ID="ddlLinkType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLinkType_SelectedIndexChanged" />
                     
                      </div>
                </div>

                
              <div class="dataRow w500">
                    <div class="dataLabel">Category<em class="requireStyle">*</em> :</div>                    
                     <div class="dataInput">
                    <asp:DropDownList ID="ddlLinkCategory" runat="server" />
                     
                      </div>
                </div>

                
              <div class="dataRow w500">
                    <div class="dataLabel">HyperLink<em class="requireStyle">*</em> :</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtHyperlink" runat="server"  />
                     
                      </div>
                </div>

                
              <div class="dataRow w500">
                    <div class="dataLabel">Description :</div>                    
                     <div class="dataInput">
                    <asp:TextBox ID="txtDescription" runat="server" Height="58px" Width="500px" TextMode="MultiLine" />
                     
                      </div>
                </div>

                
              <div class="dataRow w500">
                    <div class="dataLabel">Image Icon :</div>                    
                     <div class="dataInput">
                    <asp:TextBox ID="txtIconLink" runat="server" Height="70px" Width="500px" />
                     
                      </div>
                </div>

                
              <div class="dataRow w500">
                    <div class="dataLabel">Comment :</div>                    
                     <div class="dataInput">
                    <asp:TextBox ID="txtComment" runat="server" Height="70px" Width="500px" TextMode="MultiLine" />
                     
                      </div>
                </div>
                
                </div>
     
                   </div>
                <asp:Button CssClass="btn btn_save" ID="btnEditLink" runat="server" Text="Save" OnClick="btnEditLink_Click" />

            </asp:Panel>
      
   

