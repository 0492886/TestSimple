<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacesActivityList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Logger.FacesActivityList" %>

<span class="fatortitle">Activity log</span> 
   
          
<div class="ViewPageContainer curved">
    <div class="section"> 
        <table class="filtersList">
        
             <tr>
                <td class="filterListTitle">Staff member</td>
                <td>:</td>
                <td><asp:DropDownList ID="ddlStaffMember" runat="server" Width="192px" OnSelectedIndexChanged="ddlStaffMember_SelectedIndexChanged" AutoPostBack="true" /></td>
             </tr>
             <tr>
                <td class="filterListTitle">Log type:</td>
                <td>:</td>
                <td><asp:DropDownList ID="ddlLogType" runat="server" OnSelectedIndexChanged="ddlLogType_SelectedIndexChanged" Width="150px"  AutoPostBack="true" /></td>
             </tr>
         </table>
    </div>

    <span class="linksright lnkRemoveStyle">Removed</span>
    
    <span class="linksright lnkEditStyle">Edited, Updated</span>
    <span class="linksright lnkAssignStyle">Assigned</span>
    <span class="linksright lnkAddStyle">Added</span>
    <div class="SectionTitle">
        <asp:Label CssClass="amountFound" ID="lblMsg" runat="server" />
       <asp:CheckBox  SkinID="ChkBoxStyle" ID="cbDate" runat="server" Checked="True" AutoPostBack="true" OnCheckedChanged="cbDate_CheckedChanged" Text="Show today's logs only" />
    </div>
    
    <div class="section">  
                               
        <asp:Repeater ID="rpActivity" runat="server" OnItemDataBound="rpActivity_ItemDataBound">
                               
             <ItemTemplate>
                    <asp:HyperLink CssClass="ActivitiesList" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LogURL") %>' Target="_blank" ID="lnkView" runat="server" Text=""  >
                        <asp:Image ID="ImageItem" runat="server" />
                        <asp:Label  ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedBy") %>' Visible="false" />
                        <asp:Label  ID="lblCreatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn") %>' visible="false" />
                        <asp:Label  ID="lblActionTaken" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActionTaken") %>' visible="false" />
                        <asp:Label  ID="lblClientID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientID") %>' visible="false" />
                        <asp:Label ID="lblCaseID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CaseID") %>' visible="false" />
                        <asp:Label ID="lblReferenceID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReferenceID") %>'  Visible="false" />
                        <asp:Label  ID="lblAction" runat="server" /> 
                     </asp:HyperLink>
                    <hr class="sectionDivider" />
              </ItemTemplate>
                       
        </asp:Repeater>
    
    </div>                  
</div>