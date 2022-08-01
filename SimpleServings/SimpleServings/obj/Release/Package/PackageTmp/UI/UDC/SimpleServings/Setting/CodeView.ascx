<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CodeView.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.CodeView" %>
 <span class="hidden_msg">
 <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>
    <br />
<asp:Panel ID="pnPage" runat="server">
<div class="ViewPageContainer curved" > 
  <div class="section">
<asp:Label ID="lblCodeID" runat="server" Visible="False"></asp:Label>
        <table ID="tblCode" class="InformationListing">
               <colgroup>
               <col class="lione"  />
               <col class="co" />
               <col class="litwo" />
               </colgroup>     
           <tr>
                <td>Code Type</td>
                <td>:</td>
                <td><asp:Label ID="lblCodeType" runat="server" ></asp:Label></td>
                </tr>
                <tr>
                <td>Code Value</td>
                <td>:</td>
                <td><asp:Label ID="lblCodeValue" runat="server" ></asp:Label></td>
                </tr>
                
          <tr>
                <td>Created By</td>
                <td>:</td>
                <td><asp:Label ID="lblCreatedBy" runat="server" ></asp:Label></td>

            </tr>
            <tr>
                <td>Created On</td>
                <td>:</td>
                <td ><asp:Label ID="lblCreatedOn" runat="server" ></asp:Label></td>
            </tr>
            <tr>
             <td>Comment</td>
             <td>:</td>
             <td><asp:Label ID="lblComment" runat="server" ></asp:Label></td>
            
            </tr>                            
        </table>  
        </div>
        </div> 
        </asp:Panel> 


