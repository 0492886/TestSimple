<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddCode.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.AddCode" %>    

<span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span> 
<asp:Panel CssClass="contentBox" ID="pnPage" runat="server">

<h2 class="title2">Add Code</h2>    
          
            <div class="dataList">
                
                 <div class="dataRow">
                    <div class="dataLabel">Code Type* :</div>
                    <div class="dataInput"><asp:DropDownList ID="ddlCodeType" runat="server" Width="227px"> </asp:DropDownList></div>
                </div>
                
                <div class="dataRow">
                    <div class="dataLabel">Code Value* :</div>
                    <div class="dataInput"><asp:TextBox ID="txtCodeValue" runat="server" Width="220px"></asp:TextBox></div>
                </div>
                
                <div class="dataRow">                       
                    <div class="dataLabel">Depends On Type :</div>                    
                    <div class="dataInput"><asp:DropDownList ID="ddlDependsOnType" runat="server" Width="226px" AutoPostBack="True" OnSelectedIndexChanged="ddlDependsOnType_SelectedIndexChanged" ></asp:DropDownList></div>
                     
                </div>  
                 
                <div class="dataRow">                       
                   <div class="dataLabel">Depends On Code :</div>                    
                   <div class="dataInput">
                        &nbsp;<asp:DropDownList ID="ddlDependsOnCode" runat="server" Width="218px">
                        </asp:DropDownList>
                   </div>  
                </div>  
                
                <div class="dataRow">
                    <div class="dataLabel">Comment :</div>
                    <div class="dataInput">
                        <asp:TextBox ID="txtComment" runat="server" Height="70px" TextMode="MultiLine" Width="220px"></asp:TextBox></div>
                </div> 
                  
                <div class="dataRow">
                    <div class="dataLabel">Created By : <asp:Label CssClass="dataInput" ID="lblCreatedBy" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblCreatedByText" CssClass="dataInput" runat="server"></asp:Label></div>
                   
                </div>  
            </div>       


   <div class="clearfix"></div>   

</asp:Panel>
