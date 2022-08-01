<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReorderCodeValue.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.ReorderCodeValue" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<h2 class="title2 grey">Drag an icon below to re-order list</h2>
    
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <cc1:ReorderList ID="reorderListAjax" runat="server" ItemInsertLocation="Beginning"
                PostBackOnReorder="false"                     
                CallbackCssStyle="callbackStyle"
                cssClass="arrowAlign"
                AllowReorder="True" 
                ShowInsertItem="True"
                SortOrderField="CodeOrder"
                DataKeyField="CodeID"
                Width="400px" 
                OnItemReorder="reorderListAjax_ItemReorder">
                                
            <ItemTemplate>
                <div class="itemArea borderR">       
                    <asp:Label ID="lblCodeValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CodeDescription")%>' />
                    <asp:Label ID="lblCodeID"   Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CodeID")%>' />
                </div>
            </ItemTemplate>

            <ReorderTemplate>
                <asp:Panel ID="Panel2" runat="server" CssClass="reorderCue" />
            </ReorderTemplate>

            <DragHandleTemplate>
                <div class="dragHandle">
            </DragHandleTemplate>         
        </cc1:ReorderList>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:Label ID="lblCodeType" runat="server" Visible="False"></asp:Label>      
