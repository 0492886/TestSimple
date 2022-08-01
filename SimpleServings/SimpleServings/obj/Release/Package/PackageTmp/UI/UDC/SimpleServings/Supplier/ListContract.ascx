<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListContract.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.ListContract" %>
 
<span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel ID="pnPage" CssClass="contentBox" runat="server">
    <div class="title2 h2Size"> <asp:Label runat="server" Text="Contract List" ID="lblTitle"></asp:Label>
        <asp:LinkButton ID="lnkBtnAdd" runat="server"  CssClass="add floatR" onclick="lnkBtnAdd_Click">
            Add Contract
        </asp:LinkButton>
    </div>
    <div class="dataList">
    <div class="dgContainer">
        <asp:GridView ID="gvContract" runat="server"  CssClass="DatagridStyle table table-hover" GridLines="None"
            AutoGenerateColumns="false" onrowcommand="gvContract_RowCommand">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblContractID" runat="server" Text='<%# Eval("ContractID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblContractName" runat="server" Text='<%# Eval("ContractName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DFTA ID Number">
                    <ItemTemplate>
                        <asp:Label ID="lblContractNumber" runat="server" Text='<%# Eval("ContractNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Site Address">
                    <ItemTemplate>
                        <asp:Label ID="lblSponsorAddress" runat="server" Text='<%# Eval("SponsorAddress") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contract Type">
                    <ItemTemplate>
                        <asp:Label ID="lblContractTypeName" runat="server" Text='<%# Eval("ContractTypeName") %>'></asp:Label>
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
                        <asp:LinkButton CssClass="" ID="lnkBtnView" runat="server" CommandName="View" CommandArgument='<%# Eval("ContractID") %>' >View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </div>
<div class="clearfix"></div>   
</asp:Panel>