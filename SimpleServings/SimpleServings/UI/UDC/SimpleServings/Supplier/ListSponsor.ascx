<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListSponsor.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.ListSponsor" %>

<span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel ID="pnPage" CssClass="contentBox" runat="server">
    <div class="title2 h2Size">Sponsors List              	
        <asp:LinkButton ID="lnkBtnAdd" runat="server" onclick="lnkBtnAdd_Click" CssClass="add floatR">
            Add Sponsor
        </asp:LinkButton>
    </div>
    <div class="dataList">
    <div class="dgContainer">
    <asp:GridView ID="gvSponsor" runat="server" 
        AutoGenerateColumns="false" onrowcommand="gvSponsor_RowCommand" CssClass="DatagridStyle table table-hover"
        GridLines="None">
        <Columns>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblSponsorID" runat="server" Text='<%# Eval("SponsorID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="lblSponsorName" runat="server" Text='<%# Eval("SponsorName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    <asp:Label ID="lblSponsorAddress" runat="server" Text='<%# Eval("SponsorAddress") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Created By">
                <ItemTemplate>
                    <asp:Label ID="lblCreatedBy" runat="server" Width="150" Text='<%# Eval("CreatedByText") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Created On">
                <ItemTemplate>
                    <asp:Label ID="lblCreatedOn" runat="server" Width="150" Text='<%# Eval("CreatedOn") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkBtnView" CssClass="" runat="server" CommandName="View" CommandArgument='<%# Eval("SponsorID") %>' >View</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
    </div>
    <div class="clearfix"></div>
</asp:Panel>