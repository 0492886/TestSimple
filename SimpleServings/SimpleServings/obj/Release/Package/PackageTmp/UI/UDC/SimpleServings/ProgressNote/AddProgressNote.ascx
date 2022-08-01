<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProgressNote.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.ProgressNote.AddProgressNote" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<script language="JavaScript" src="../../../Javascript/spell.js" type="text/javascript"></script>


<asp:Panel ID="pnPage" runat="server">
    <table class="InformationListing" style="display:none">
        <tr> 
            <td>Note Type</td>
            <td><asp:DropDownList ID="ddlNoteType" runat="server" /></td>
        </tr>
    </table>
    
    <asp:Label ID="lblCreatedBy" runat="server" Text="" Visible="false" />
    <asp:Label ID="lblNoteID" runat="server" Text="" Visible="false" />
    <div class="clearfix"></div>

    <div class="noteapp">
        <asp:TextBox ID="txtNote" runat="server" CssClass="w763 noteBox" TextMode="MultiLine" />
    </div>
<asp:Button CssClass="btn btnEndofPage" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <%--
    
       <FTB:FreeTextBox ID="txtNote" runat="server" AllowHtmlMode="false" EnableHtmlMode="false" Focus="true" Width="100%"
         ToolbarLayout="FontFacesMenu;Bold,Italic,Underline,RemoveFormat;JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent" >
             <TOOLBARS>
                <FTB:TOOLBAR >
                    <FTB:NetSpell  />   
                </FTB:TOOLBAR>
            </TOOLBARS>
        </FTB:FreeTextBox>
    </div>
     --%>

    <%--      <input class="btnStyle btnEndofPage" id="btnSaveDraft" type="button" value="Save Draft" runat="server" onserverclick="btnSaveDraft_ServerClick" />
            <asp:Label ID="lblSaveTime" runat="server" Text="" />
            --%>

            
            <%--<asp:Label ID="lblWarning" runat="server" Text= "Drafts are stored for a day.<br />Overnight, a draft automatically becomes a saved note." />--%>

</asp:Panel>

<asp:Label ID="lblReferenceID" runat="server" Visible="False" ></asp:Label>
<asp:Label CssClass="msglabel" ID="lblError" runat="server" ForeColor="red" ></asp:Label>
<asp:Label ID="lblMsg" CssClass="msglabel" runat="server" ></asp:Label>  