<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CodeList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.CodeList" %>
<%@ Register Src="UserGroupList.ascx" TagName="UserGroupList" TagPrefix="uc2" %>
<%@ Register Src="ReorderCodeValue.ascx" TagName="ReorderCodeValue" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>

<asp:Panel ID="pnPage"  CssClass="contentBox" runat="server">
   <div class="title2"><span class="h2Size">Code Management</span>

    <ul class="floatR">
                <li><asp:LinkButton CssClass="edit floatR" ID="lnkBtnReoderCode" runat="server">Reorder Code Value</asp:LinkButton></li>
                <li><asp:HyperLink ID="hlInsertCode" runat="server"  CssClass="add floatR">Add Code</asp:HyperLink></li><%--Target="_blank"--%>

                <li><asp:HyperLink CssClass="add floatR" ID="hlAddRule" runat="server">Add Rule</asp:HyperLink></li><%-- Target="_blank"--%>
                <li><asp:HyperLink CssClass="check floatR" ID="hlViewRules" runat="server" >View Rules</asp:HyperLink></li> <%--Target="_blank"--%>             
            </ul>
     </div>

    <asp:Label ID="lblCodeID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodeType" runat="server" Visible="False"></asp:Label>
    <uc2:UserGroupList ID="UserGroupList1" Visible="false" runat="server" EnableViewState="true"></uc2:UserGroupList>

    <div class="dataList">
        <div class="SectionTitle tagscontainer">            
           
            <div class="dataRow">
            <asp:CheckBox ID="cbDeactiveCodes" runat="server" Text ="&nbsp;Show Deactivated" AutoPostBack="true" OnCheckedChanged="cbDeactiveCodes_CheckedChanged" />
            </div>
                 <div class="clearfix"></div>  
            <div class="floatL dataRow">
                 CodeType :
                <asp:DropDownList ID="ddlCodeType" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddlCodeType_SelectedIndexChanged"></asp:DropDownList>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                 <asp:Label ID="lblCategories" runat="server" Text="Categories:" Visible="false"></asp:Label>
                <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged"></asp:DropDownList>
           </div>
            
        </div>
      <div class="clearfix"></div>  

        <div class="gridViewWrapper dgContainer">
            <asp:GridView CssClass="DatagridStyle table table-hover" ID="gvCodeDescription" runat="server" AutoGenerateColumns="False"  GridLines="None" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvCodeDescription_PageIndexChanging" >
                <AlternatingRowStyle CssClass="DatagridStyleAltRow" />
                <PagerStyle CssClass="DatagridStylePgRow" />  
                <Columns>
                    <asp:TemplateField HeaderText="Code ID">
                        <ItemTemplate>
                            <asp:Label ID="lblCodeID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CodeID") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CodeType" HeaderText="Code Type" Visible="False" />
                    <asp:BoundField DataField="CodeDescription" HeaderText="Value" />
                    <asp:BoundField DataField="CodeOrder" HeaderText="Code Order" />       
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBtnExclude" CssClass="btn_floatR right" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodeID") %>' Visible='<%#CanEdit() %>' OnClick="lnkBtnExclude_Click"   >Exclude</asp:LinkButton>
                        </ItemTemplate>                 
                    </asp:TemplateField>
                    <asp:TemplateField  >
                        <ItemTemplate >
                            <asp:LinkButton ID="lnkBtnRemove" CssClass="btn_floatR right" runat="server" Visible='<%#Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive")) && CanDelete() %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodeID") %>'  OnClick="lnkBtnRemove_Click" >Deactivate</asp:LinkButton>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to deactivate the code value? If so, please click OK button" TargetControlID="lnkBtnRemove"></cc1:ConfirmButtonExtender>
                        </ItemTemplate>                 
                    </asp:TemplateField>
                    <asp:TemplateField  >
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBtnActivate" CssClass="btn_floatR right" runat="server" Visible='<%#!Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive")) && CanAdd() %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodeID") %>'  OnClick="lnkBtnActivate_Click" >Activate</asp:LinkButton>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Are you sure you want to Activate the code value? If so, please click OK button" TargetControlID="lnkBtnActivate"></cc1:ConfirmButtonExtender>
                        </ItemTemplate>                 
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--<asp:HyperLink ID="hlEditCode" CssClass="btn_floatR btn_edit right" runat="server" Visible='<%#CanEdit() %>' NavigateUrl='<%# "~/UI/Page/SimpleServings/Setting/EditCode.aspx?CodeID=" + DataBinder.Eval(Container.DataItem, "CodeID") %>' Target="_blank" Text="Edit Code" />
                       --%>
                                <asp:HyperLink ID="hlEditCode" CssClass="btn_floatR btn_edit right" runat="server" Visible='<%#CanEdit() %>' NavigateUrl='<%# "~/UI/Page/SimpleServings/Setting/EditCode.aspx?CodeID=" + DataBinder.Eval(Container.DataItem, "CodeID") %>'  Text="Edit Code" />
                       
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns> 
            </asp:GridView>
        </div>
    </div>
<div class="clearfix"></div>  
</asp:Panel>

<asp:LinkButton ID="lnkBtnReorderPopupClose" runat="server" Visible="true" />
<cc1:ModalPopupExtender ID="modalPopupReorder" runat="server"  
    TargetControlID="lnkBtnReoderCode" PopupControlID="panelReorder"
    BackgroundCssClass="modalBackground popupBg" CancelControlID="lnkBtnReorderPopupClose"
    DropShadow="False" >
</cc1:ModalPopupExtender>      
 
<asp:Panel ID="panelReorder" runat="server" CssClass="modalPopup ScrollPopUp" Style="height:auto; max-height:400px;height:400px; padding-right:15px; overflow:auto;">
        <asp:LinkButton CssClass="linksright lnkCloseStyle right" ID="lnkBtnClose" Text="close" runat="server" OnClick="lnkBtnClose_Click"></asp:LinkButton>  
        <uc3:ReorderCodeValue id="ReorderCodeValue1" runat="server"></uc3:ReorderCodeValue>
</asp:Panel>

