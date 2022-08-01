<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CodeGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.CodeGrid" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div class="gridViewWrapper dgContainer">
<asp:GridView CssClass="DatagridStyle" ID="gvCodeDescription" runat="server" AutoGenerateColumns="False"  GridLines="None" AllowPaging="true" PageSize='<%# Convert.ToInt32(ConfigurationManager.AppSettings["GridPageSize"]) %>' OnPageIndexChanging="gvCodeDescription_PageIndexChanging" >
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
               <asp:LinkButton ID="lnkBtnExclude" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodeID") %>' Visible='<%#CanEdit() %>' OnClick="lnkBtnExclude_Click"   >Exclude</asp:LinkButton>            
            </ItemTemplate>                 
        </asp:TemplateField>
      <asp:TemplateField>
            <ItemTemplate>
               <asp:LinkButton ID="lnkBtnRemove" runat="server" Visible='<%#Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive")) && CanDelete() %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodeID") %>'  OnClick="lnkBtnRemove_Click" OnClientClick="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');" >Deactivate</asp:LinkButton>
             <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to deactivate the code value? If so, please click OK button" TargetControlID="lnkBtnRemove">
            </cc1:ConfirmButtonExtender>
            </ItemTemplate>                 
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
               <asp:LinkButton ID="lnkBtnActivate" runat="server" Visible='<%#!Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive")) && CanAdd() %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodeID") %>'  OnClick="lnkBtnActivate_Click"  >Activate</asp:LinkButton>
             <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Are you sure you want to Activate the code value? If so, please click OK button" TargetControlID="lnkBtnActivate">
            </cc1:ConfirmButtonExtender>
            </ItemTemplate>                 
        </asp:TemplateField>
        <asp:TemplateField>
                 <ItemTemplate>
                        <asp:HyperLink ID="hlEditCode" runat="server" Visible='<%#CanEdit() %>' NavigateUrl='<%# "~/UI/Page/SimpleServings/Setting/EditCode.aspx?CodeID=" + DataBinder.Eval(Container.DataItem, "CodeID") %>' Target="_blank" Text="Edit Code" />
                       
                           
                 </ItemTemplate>
                        </asp:TemplateField>
           </Columns> 
            

</asp:GridView>
</div>