<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuItemGridChangeHistory.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuItemGridChangeHistory" %>


<asp:Panel ID="pnPage" runat="server">

<asp:Label ForeColor="Green" runat="server" ID="lblMsg"> </asp:Label>
<div class="dgContainer">
   
<asp:GridView ID="gvMenuItemGridHistory" runat="server" GridLines="None" AutoGenerateColumns="false"  CssClass="DatagridStyle table table-hover" AlternatingRowStyle-BorderStyle="Solid" BorderColor="Black">
<Columns>
   
<%-- <asp:TemplateField HeaderText = "">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
     </asp:TemplateField>--%>

     <asp:TemplateField HeaderText="Recipe ID" >
     <ItemTemplate>
         <asp:Label ID="lblRecipeIDText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID")%>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="Recipe Name" >
     <ItemTemplate>
         <asp:Label ID="lblRecipeText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipeNameText")%>' ></asp:Label> 
     </ItemTemplate>
    </asp:TemplateField>

   <asp:TemplateField HeaderText="Week In Cycle" >
     <ItemTemplate>
         <asp:Label ID="lblWeekInCycleText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WeekInCycle") %>'></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Action" >
     <ItemTemplate>
         <asp:Label ID="lblActionText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Action") %>'></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
     
    <%--<asp:TemplateField HeaderText="From" >
        <ItemTemplate>
            <asp:Label ID="lblFromText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OriginalDayOfWeekText").ToString() + " - "+ DataBinder.Eval(Container.DataItem, "OriginalMenuItemTypeText").ToString()%>'  ></asp:Label> 
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="To" >
     <ItemTemplate>
            <asp:Label ID="lblToText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NewDayOfWeekText").ToString() + " - "+ DataBinder.Eval(Container.DataItem, "NewMenuItemTypeText").ToString()%>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>--%>

     <asp:TemplateField HeaderText="Changed On" >
     <ItemTemplate>
            <asp:Label ID="lblToText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn")%>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Changed By" >
     <ItemTemplate>
            <asp:Label ID="lblToText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedByText")%>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

</Columns>
</asp:GridView>

</div>
</asp:Panel>