<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeStatusHistory.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.RecipeStatusHistory" %>


<div class="ViewPageContainer curved">
<asp:Panel ID="pnPage" runat="server" >

    <div class="SectionTitle">
    <asp:Label ID="lblMsg" CssClass="msglabel" runat="server"></asp:Label>
        <asp:Label ID="lblCount"  runat="server"></asp:Label>
 </div>
<asp:GridView ID="gvStatusHistory" CssClass="DatagridStyle table table-hover" GridLines="None" runat="server" AutoGenerateColumns="False">
      
<Columns>
     <asp:TemplateField HeaderText="Recipe ID" Visible="false">
     <ItemTemplate>
                <asp:Label ID="lblRecipeID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Status">
     <ItemTemplate>
            <asp:Label ID="lblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusText") %>'  Width="125px"></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderText="Comments">
     <ItemTemplate>
            <asp:Label ID="lblComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Comments") %>'  Width="125px"></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    
     <asp:TemplateField HeaderText="Status Date">
     <ItemTemplate>
            <asp:Label ID="lblStatusDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusDate") %>'  Width="125px"></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Staff">
     <ItemTemplate>
            <asp:Label ID="lblStaff" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedByText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
     
    
    </Columns>
 </asp:GridView>
 
</asp:Panel></div>