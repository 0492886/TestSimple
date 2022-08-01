<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuStatusHistoryGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuStatusHistoryGrid" %>


<asp:Panel ID="pnPage" runat="server">

<asp:Label CssClass="labme" ID="lblCount" runat="server"></asp:Label> 
<div class="dgContainer">
<asp:GridView ID="gvMenusHistory" runat="server" CssClass="DatagridStyle table table-hover" GridLines="None"
        AutoGenerateColumns="false">   
<Columns>        
     <asp:TemplateField Visible="false">
     <ItemTemplate>
                <asp:Label ID="lblMenuHistoryID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuStatusHistoryID") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField Visible="false">
     <ItemTemplate>
                <asp:Label ID="lblMenuID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuID") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField Visible="false">
     <ItemTemplate>
                <asp:Label ID="lblStatusID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusID") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>


    <asp:TemplateField HeaderText="Status">
     <ItemTemplate>
            <asp:Label ID="lblStatusText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusText") %>' ></asp:Label>
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

    <asp:TemplateField HeaderText="Created By">
     <ItemTemplate>
            <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedByText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
         
    </Columns>
 </asp:GridView>
 </div>
</asp:Panel>