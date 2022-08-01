<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewProgressNote.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.ProgressNote.ViewProgressNote" %>


<asp:Label CssClass="msglabel" ID="lblMsg" runat="server" />
<div class="ViewPageContainer"> 
<div class="section">
        
    <div class="InformationListing">
                    <asp:Label ID="lblNoteID" runat="server" Visible="false"></asp:Label></div>

                <div class="row">
                    
                 </div>
                    
                 <div class="row">    
                    <div class="input-title">Note Type :</div>
                     
                    <div class="input-field"><asp:Label ID="lblNoteType" runat="server" Text=""></asp:Label></div>
                </div>
                
                 <div class="row">
                    <div class="input-title">Created By :</div>
                     
                    <div class="input-field"><asp:Label ID="lblCreatedBy" runat="server" Text=""></asp:Label></div>
                 </div> 
                    <div class="input-title">Created On :</div>
                     
                    <div class="input-field"><asp:Label ID="lblCreatedOn" runat="server" Text=""></asp:Label></div>
                </div>
               
                <div class="row">
                  <h1 class="title">Note Content</h1>
                    <div class="noteContent">
                    <asp:Label  ID="lblNoteDescription" runat="server" Text=""></asp:Label></div>
                </div>


</div>


