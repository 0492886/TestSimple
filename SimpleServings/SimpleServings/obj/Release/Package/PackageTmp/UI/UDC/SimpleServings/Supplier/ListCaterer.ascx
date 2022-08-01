<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListCaterer.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.ListCaterer" %>
 
<span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel ID="pnPage" CssClass="contentBox" runat="server">
    <div class="title2 h2Size">Caterers List
        <asp:LinkButton ID="lnkBtnAdd" runat="server" onclick="lnkBtnAdd_Click" CssClass="add floatR">
            Add Caterer
        </asp:LinkButton>
    </div>
    <div class="dataList">
    <div class="dgContainer">
        <asp:GridView ID="gvCaterer" runat="server"  CssClass="DatagridStyle table table-hover" GridLines="None"
            AutoGenerateColumns="false" onrowcommand="gvCaterer_RowCommand">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblCatererID" runat="server" Text='<%# Eval("CatererID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCatererName" runat="server" Text='<%# Eval("CatererName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="lblCatererAddress" runat="server" Text='<%# Eval("CatererAddress") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Created By">
                    <ItemTemplate>
                        <asp:Label ID="lblCreatedBy" Width="150" runat="server" Text='<%# Eval("CreatedByText") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Created On">
                    <ItemTemplate>
                        <asp:Label ID="lblCreatedOn" Width="150" runat="server" Text='<%# Eval("CreatedOn") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton CssClass="" ID="lnkBtnView" runat="server" CommandName="View" CommandArgument='<%# Eval("CatererID") %>' >View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </div>
    <div class="clearfix"></div>

</asp:Panel>