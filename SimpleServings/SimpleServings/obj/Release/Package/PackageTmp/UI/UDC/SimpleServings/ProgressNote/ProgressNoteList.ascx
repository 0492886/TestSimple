<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgressNoteList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.ProgressNote.ProgressNoteList" %>


<asp:Label ID="lblTitle" CssClass="fatortitle" runat="server"></asp:Label>
<asp:Label ID="lblMsg" CssClass="msglabel" runat="server" />
<asp:Panel ID="pnPage" CssClass="contentLeftPad" runat="server">
    
    <asp:Panel ID="headerPanel" runat="server">
        
          
        
        <div class="ViewPageContainer">
                
            <div class="section"> 
            
            <div class="SectionTitle">
            
                <table class="filtersList">
                    <tr>
                        <td class="filterListTitle">Note Type</td>
                        <td ><asp:DropDownList ID="ddlNoteType" runat="server" OnSelectedIndexChanged="ddlNoteType_SelectedIndexChanged" AutoPostBack="True" /></td>
                    </tr>
                    
                </table>
                
                
                <table style="float:left; margin:5px 0 0 30px; ">
                    <tr>
                    <td>
                    <asp:Label CssClass="amountFound" ID="Label1" 

    runat="server" Text="" />
                    <asp:CheckBox  SkinID="ChkBoxStyle"  ID="chxShowEntire" 

    runat="server" Text="Show entire note body" AutoPostBack="True" 

    OnCheckedChanged="chxShowEntire_CheckedChanged"/>
                    </td>
                    </tr>       
                </table>
                
                
                <asp:HyperLink CssClass="btn_floatR btn_add" ID="hlAddProgressNote" runat="server">Add Note</asp:HyperLink>   
        
        
            </div>
            
            
            
            
            
            
            
            
                    <asp:DataList ID="lstNotes" DataKeyField="NoteID" runat="server" OnItemDataBound="lstNotes_ItemDataBound" CssClass="stretcherClass">
            <ItemTemplate>
                <div class="ViewPageContainer">
                
    
                       <asp:Label ID="lblNoteID" runat="server" Visible="false" Text='<%#Eval("NoteID") %>' />

                       
                        
                        <asp:HyperLink CssClass="lnkEditStyle linksright" ID="lnkEditDraft" runat="server" Target="_blank"  NavigateUrl='<%# "~/UI/Page/SimpleServings/ProgressNote/AddProgressNotes.aspx?EditNoteID=" + Eval("NoteID")+"&FairHearingID="+Eval("FairHearingID")%>' Visible="false">Edit</asp:HyperLink>
                        <asp:HyperLink CssClass="lnkViewStyle linksright"  ID="lnkViewNote" runat="server" Target="_blank"  NavigateUrl='<%# "~/UI/Page/SimpleServings/ProgressNote/ViewProgressNote.aspx?NoteID=" + Eval("NoteID") %>' Visible="true">View in a separate Window</asp:HyperLink>
      
                         
                               <div class="InformationListing">

                                  
                               <div class="row">
                                    <div class="input-title">Note Type :</div>
                           
                                    <div class="input-field"><asp:Label ID="lblNoteType" runat="server" Text='<%#Eval("NoteType") %>' /></div>
                                </div>
                                 
                                 <div class="row">
                                    <div class="input-title">Created By :</div>
                                    <div class="input-field"><asp:Label ID="lblCratedBy" runat="server" Text='<%# Eval("CreatedByText") %>' />
                                        <asp:Label ID="lblFairHearingID" runat="server" Text='<%# Eval("FairHearingID") %>' Visible="False" />
                                    </div>
                                    
                                  </div>  
                                
                                <div class="row">    
                                    <div class="input-title">Created On :</div>
                                    <div class="input-field"><asp:Label ID="lblCreatedOn" runat="server" Text='<%# Eval("CreatedOn") %>' /></div>
                                </div>
                                
                               
                                <div class="row">
                                  <code><asp:Label ID="lblNote" runat="server" Text='<%# Eval("NoteDescription") %>' /></code>
                                </div>
                                
                                
                        </div>
                        
                        
                  
               </div>
            </ItemTemplate>
        </asp:DataList>
      
        <div class="SectionTitle curvedBottom">
            <span class="mainPager">
               <asp:button ID="cmdFirst" runat="server" text="<<"  Visible="false" OnClick="cmdFirst_Click" />

                <asp:button ID="cmdPrev" runat="server" text="<" OnClick="cmdPrev_Click" Visible="false" />
                <asp:Panel ID="pnPaging" runat="server"></asp:Panel>
                <asp:label ID="lblCurrentPage"  style="display:none" runat="server" />
                <asp:button ID="cmdNext" runat="server" text=">" OnClick="cmdNext_Click" Visible="false" />
                <asp:button ID="cmdLast" runat="server" text=">>" OnClick="cmdLast_Click" Visible="false" />

             </span>
        </div> 
        
    </div>
       
    <asp:Label ID="lblFairHearingID" runat="server" Visible="False" />
    <asp:Label ID="lblDraftorSubmitted" runat="server" Visible="False" />
         
</asp:Panel>  
            
            
            
            
           
          

        
        
        <!--End Viewpagecontainer-->

           
        
    </asp:Panel>
    
       
          <%-- <div class="section">
                <div class="SectionTitle">
                <asp:Label CssClass="amountFound" ID="lblSummary" runat="server" Text="" />
                <asp:CheckBox  SkinID="ChkBoxStyle"  ID="chxShowEntire" runat="server" Text="Show entire note body" AutoPostBack="True" OnCheckedChanged="chxShowEntire_CheckedChanged"/>
            </div> --%>
            
            






