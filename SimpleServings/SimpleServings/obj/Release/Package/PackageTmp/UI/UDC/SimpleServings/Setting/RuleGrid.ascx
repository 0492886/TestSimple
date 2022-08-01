<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RuleGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.RuleGrid" %>



 <span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>
    <br />
    
<asp:Panel ID="pnPage" runat="server">

        
<asp:Label CssClass="labme" ID="lblCount" runat="server"></asp:Label> 
           
  <div class="gridViewWrapper dgContainer">             
<asp:GridView CssClass="DatagridStyle table table-hover" GridLines="None" ID="gvRules" runat="server"  AutoGenerateColumns="False" >
     <AlternatingRowStyle CssClass="" />             
 
<Columns>
    <asp:TemplateField Visible="False">
        <ItemTemplate>
        
           <asp:CheckBox  SkinID="ChkBoxStyle" ID="cbSelected" runat="server"  />
        </ItemTemplate>
    </asp:TemplateField>   
    
    
     <asp:TemplateField Visible="false">
     <ItemTemplate>
                <asp:Label ID="lblRuleID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RuleID") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Rule Description">
     <ItemTemplate>
            <asp:Label ID="lblRuleDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RuleDescription") %>'  Width="125px"></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    
   
    <asp:TemplateField HeaderText="Staff Specific">
     <ItemTemplate>
            <asp:Label ID="lblStaffSpecific" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsStaffSpecificText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Custom Message">
     <ItemTemplate>
            <asp:Label ID="lblCustomMessage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomMessage") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Active">
     <ItemTemplate>
            <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsActiveText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="RuleID" DataNavigateUrlFormatString="~/UI/Page/SimpleServings/Setting/EditRule.aspx?RuleID={0}" Target="_blank" Text="Edit Rule" />

    
    </Columns>
 </asp:GridView>
</div>
</asp:Panel>