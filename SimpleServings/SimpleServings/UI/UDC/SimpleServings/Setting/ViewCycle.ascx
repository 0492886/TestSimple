<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewCycle.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.ViewCycle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<span class="hidden_msg"><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel CssClass="dataList" ID="pnPage" runat="server">
<div class="contentBox">
<div class="title2 h2Size">Menu Cycle<asp:HyperLink ID="hlAddRecipe" runat="server" CssClass="add floatR" Text="Add Menu Cycle" 
                    NavigateUrl="~/UI/Page/SimpleServings/Setting/AddEditMenuCycle.aspx" >
                </asp:HyperLink>
</div>
<div class="dataList">
<asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
   
    
        <asp:CheckBox ID="chxAllMenuCycle" runat="server" Text="Show All Menu Cycles" AutoPostBack="true"
            OnCheckedChanged="chxAllMenuCycle_CheckedChanged" />
     
<div class="dgContainer">
<asp:GridView  CssClass="DatagridStyle table table-hover"  ID="gvMenuCycles" runat="server"  
    AutoGenerateColumns="false" >
<Columns>
        <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
                <asp:Label ID="lblMenuCycleID" runat="server" text='<%#Eval("MenuCycleID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="Cycle">
            <ItemTemplate>
                <asp:Label ID="lblMenuCycleName" runat="server" text='<%#Eval("CycleName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Start Date">
             <ItemTemplate>
                <asp:Label ID="lblStartDate" runat="server" text='<%#Eval("CycleStartDate") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="End Date">
             <ItemTemplate>
                <asp:Label ID="lblEndDay" runat="server" text='<%#Eval("CycleEndDate") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
     
        <asp:TemplateField HeaderText="Active">
             <ItemTemplate>
                <asp:Label ID="lblIsActive" runat="server" text='<%#Eval("IsActiveText") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    
         <asp:HyperLinkField 
        DataNavigateUrlFields="MenuCycleID" 
        ControlStyle-CssClass="" 
        DataNavigateUrlFormatString="~/UI/Page/SimpleServings/Setting/AddEditMenuCycle.aspx?MenuCycleID={0}"
        Text="Edit" /> 
         
        <asp:TemplateField>
            <ItemTemplate>
               <asp:LinkButton ID="lnkBtnRemove" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuCycleID") %>'  OnClick="lnkBtnRemove_Click" OnClientClick="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');" >Remove</asp:LinkButton>
             <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to delete the cycle? If so, please click OK button" TargetControlID="lnkBtnRemove">
            </cc1:ConfirmButtonExtender>
            </ItemTemplate>                 
        </asp:TemplateField>  
    
            
</Columns>
</asp:GridView>
</div>
</div>
</div>
</asp:Panel>









