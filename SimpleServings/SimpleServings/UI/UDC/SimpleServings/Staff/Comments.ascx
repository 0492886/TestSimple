<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.Comments" %>
<div class="contentBox marginTopFix">
<div class="title2 h2Size">Add Comments 
 <a class="back floatR" href="JavaScript:history.back();">Back</a>   
 </div>

          <div class="dataList">  
          <div class="dataRow">
                    <div class="dataLabel">Comment :</div>                    
                     <div class="dataInput">
                     <asp:TextBox CssClass="txtBoxNoteStyle" ID="txtComment" runat="server" TextMode="MultiLine" Width="400" Height="150" />
                     <asp:Label ID="lblStaffID" runat="server" Visible="False" />
                     <asp:Label ID="lblSummary" runat="server" Visible="False" />
                     
                      </div>
           </div>
           </div> 
    <asp:Button  CssClass="btn btn_save" ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />

</div>