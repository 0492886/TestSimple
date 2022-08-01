<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivityList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Logger.ActivityList" %>

<script>

$(‘tr:odd’).css(‘background-color’, ‘#ccc’);
</script>

<div class="contentLeftPad">
<span class="fatortitle">Activity log</span>

  <div class="ViewPageContainer curved">
        
        <div class="section">
            
            <div class="InformationListing">
                <div class="row">
                    <div class="input-title">Select Staff Member:</div>
                    <div class="input-field"><asp:DropDownList ID="ddlStaffMember" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStaffMember_SelectedIndexChanged" /></div>
                </div>
                <div class="row">
                    <div class="input-title">Select Log Type:</div>
                    <div class="input-field"><asp:DropDownList ID="ddlLogType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLogType_SelectedIndexChanged" /></div>
                </div>
                <div class="row">
                    <div class="input-title">Show Today's Logs Only:</div>
                    <div class="input-field"><asp:CheckBox ID="cbDate" runat="server" Checked="True" AutoPostBack="true" OnCheckedChanged="cbDate_CheckedChanged"/></div>
                </div>
            </div>
        
        </div>
        
        
        
        <div class="margthre" style="padding-left:300px;">
        
        <img src="~/UI/Imgs/setting/action.gif" alt="" runat="server" ID="action" />
        
        </div>
        
        
        
        <div class="section">
        
                 <div class="SectionTitle"><asp:Label CssClass="amountFound" ID="lblMsg" runat="server"></asp:Label > </div>                 
                 
                 <asp:Repeater  ID="rpActivity" runat="server" OnItemDataBound="rpActivity_ItemDataBound" >
                     <SeparatorTemplate></SeparatorTemplate>
                     
                     <ItemTemplate >
                          
                          <div class="sepbox"> 
                           
                           <asp:HyperLink NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LogURL") %>' Target="_blank" ID="lnkView" runat="server"> 
                           
                                <asp:Image ID="ImageItem" runat="server" />
                                <asp:Label  ID="lblAction" runat="server"></asp:Label > 
                            </asp:HyperLink> 
                            
                            <asp:Label  ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedBy") %>' Visible="false" />
                                <asp:Label  ID="lblCreatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn") %>' visible="false" />
                                <asp:Label  ID="lblActionTaken" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActionTaken") %>' visible="false" />
                                <asp:Label ID="lblFairHearingID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FairHearingID") %>' visible="false" />
                                <asp:Label ID="lblReferenceID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReferenceID") %>'  Visible="false" />
                                 
                          <!-- <hr style="border:solid;width:100%;"  color="#e0dddd" size="0.6" /> -->
                          
                          </div> <!--sepbox-->
                                 
                     </ItemTemplate>
                               
                     <SeparatorTemplate> </SeparatorTemplate>
                           
                 </asp:Repeater>
                 
                 </div>
                          
</div></div>
