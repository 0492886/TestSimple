<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddLink.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.AddLink" %>

<div class="contentBox">
    
<div class="title2 h2Size">Add Link                      
                     <asp:LinkButton ID="lnkbViewLinks"  CssClass="back floatR" runat="server" Text="Back To List" OnClick="lnkbViewLinks_Click"></asp:LinkButton>
</div>
   
<span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>
 
<asp:Panel CssClass="dataList" ID="pnPage" runat="server">    
 <div class="dataRow">
                    <div class="dataLabel">Type</div>                    
                     <div class="dataInput">
                     <asp:DropDownList ID="ddlLinkType" runat="server" Width="227px" AutoPostBack="True" OnSelectedIndexChanged="ddlLinkType_SelectedIndexChanged"> </asp:DropDownList>                     
                      </div>
                </div>

                 <div class="dataRow">
                    <div class="dataLabel">Category</div>                    
                     <div class="dataInput">
                     <asp:DropDownList ID="ddlLinkCategory" runat="server" Width="226px" ></asp:DropDownList>                     
                      </div>
                </div>

                 <div class="dataRow">
                    <div class="dataLabel">Hyperlink</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtHyperlink" runat="server" Width="220px"></asp:TextBox>                     
                      </div>
                </div>

                 <div class="dataRow">
                    <div class="dataLabel">Description(Title)</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtDescription" runat="server" Height="70px" Width="220px" TextMode="MultiLine"></asp:TextBox>                     
                      </div>
                </div>

                 <div class="dataRow">
                    <div class="dataLabel">Icon Hyperlink</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtIconLink" runat="server" Height="70px" Width="220px" ></asp:TextBox>                     
                      </div>
                </div>

                 <div class="dataRow">
                    <div class="dataLabel">Comment</div>                    
                     <div class="dataInput">
                     <asp:TextBox ID="txtComment" runat="server" Height="70px" Width="220px" TextMode="MultiLine"></asp:TextBox>                     
                      </div>
                </div>                 
                   
                <asp:Button ID="btnAddLink" CssClass="btn btn_save" runat="server" Text="Save" OnClick="btnAddLink_Click" />
             
</asp:Panel>
</div>
   <div class="clearfix"></div>   