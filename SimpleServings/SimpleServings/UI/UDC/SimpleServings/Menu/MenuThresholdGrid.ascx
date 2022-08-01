<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuThresholdGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuThresholdGrid" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>

<asp:Panel ID="pnPage" runat="server">

<asp:Label CssClass="labme" ID="lblCount" runat="server"></asp:Label> 
        
<asp:GridView CssClass="DatagridStyle table table-hover" GridLines="None" ID="gvMenusthreshold" runat="server"  AutoGenerateColumns="False" >
     <AlternatingRowStyle CssClass="DatagridStyleAltRow" />             
 
<Columns>
        
     <asp:TemplateField Visible="false">
     <ItemTemplate>
                <asp:Label ID="lblMenuThresholdID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ThresholdID") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Nutrient Name">
     <ItemTemplate>
            <asp:Label ID="lblNutrientName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NutrientName") %>'  Width="125px"></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Contract Type">
     <ItemTemplate>
            <asp:Label ID="lblContractTypeText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContractTypeText") %>'  Width="125px"></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Periodical Type">
     <ItemTemplate>
            <asp:Label ID="lblPeriodicalText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PeriodicalText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Low Threshold">
     <ItemTemplate>
            <asp:Label ID="lblLowThreshold" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LowThreshold") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Inequality Type">
     <ItemTemplate>
            <asp:Label ID="lblInequalityType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InequalityTypeText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderText="High Threshold">
     <ItemTemplate>
            <asp:Label ID="lblHighThreshold" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HighThreshold") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Created On">
     <ItemTemplate>
            <asp:Label ID="lblCreatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
  <asp:HyperLinkField DataNavigateUrlFields="ThresholdID" ControlStyle-CssClass="" DataNavigateUrlFormatString="~/UI/Page/SimpleServings/Menu/AddEditMenuThreshold.aspx?MenuThresholdID={0}" Text="Edit" />            
    
    <asp:TemplateField>
     <ItemTemplate>
             <asp:LinkButton ID="lnkBtnRemove" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ThresholdID") %>'
                    OnClick="lnkBtnRemove_Click">Delete</asp:LinkButton>
            <AjaxToolKit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to delete the menu? If so, please click OK button" TargetControlID="lnkBtnRemove">
        </AjaxToolKit:ConfirmButtonExtender>
     </ItemTemplate>
    </asp:TemplateField>

    </Columns>
 </asp:GridView>
</asp:Panel>