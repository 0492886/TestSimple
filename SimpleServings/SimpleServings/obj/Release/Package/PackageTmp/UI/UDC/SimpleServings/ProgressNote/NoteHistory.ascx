<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NoteHistory.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.ProgressNote.NoteHistory" %>

  

<span class="hidden_msg"><asp:Label ID="lblCount" runat="server" ForeColor="Red"></asp:Label></span>

<asp:DataList ID="dlProgressNotes" runat="server" OnItemCommand="dlProgressNotes_ItemCommand" CssClass="stretcherClass">
    <ItemTemplate>
 
        <div class="ViewPageContainer">
                    <div class="InformationListing">
                    <table width="100%" cellspacing="4" cellpadding="4" style="margin-bottom:7px; margin-top:7px; border-bottom: 1px solid #EAEAEA;">
                    <tr>
                    <td>
                        <div class="clearfix"></div>
                      <div class="input-title" style="margin-right:30px; display:none;">
                          <div class="dataLabel">Created By :</div> 

                            <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedByText") %>' />
                            <asp:Label ID="lblNoteID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NoteID") %>' Visible="False" />
                        </div>
                        <br />  
                    </td>
                    <td>
                         <div class="input-title" style="display:none;">
                             <div class="dataLabel">Created On :</div> 
                            <asp:Label ID="lblCreatedOn" runat="server" Font-Bold="True" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn") %>' />                            
                        </div>
                       <br />  
                    </td>
                    
                   <td style="width:100%;">
                       <code>
                        <asp:Label  CssClass="span8" ID="lblProgressNotes" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "NoteDescription") %>'></asp:Label>
                    </code>

                    </td>

                    <td>
                        <div class="input-title" style="margin-left:30px; width:5%;">
                            <asp:LinkButton ID="lbtnRemove" CssClass="btn_floatR btn_delete" runat="server" Visible='<%#CanDelete()%>' CommandName="Remove">Remove</asp:LinkButton>
                        </div>
                    </td>
                    </tr>                    
                    </table>
<%--                    <code>
                        <asp:Label  CssClass="span8" style="margin:10px; font-weight:bold;" ID="lblProgressNotes" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "NoteDescription") %>'></asp:Label>
                    </code>--%>
                    <div class="clearfix"></div>
                    <div></div>
                    
                </div>
        </div>

    </ItemTemplate>
</asp:DataList>

        
<asp:Label ID="lblNoteTypeID" runat="server" Visible="False" />
<asp:Label ID="lblRefID" runat="server" Visible="False" />
 
