<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.ContractGrid" %>

<asp:Panel ID="pnPage" runat="server" CssClass="dgContainer">
    <asp:GridView ID="gvContract" runat="server"  CssClass="DatagridStyle table table-hover" 
        GridLines="None"
        AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cbCheck" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblContractID" runat="server" Visible="false" 
                        Text='<%# DataBinder.Eval(Container.DataItem,"ContractID")%>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblContractName" runat="server" Visible="true" 
                        Text='<%# DataBinder.Eval(Container.DataItem,"ContractName")%>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <%--<asp:BoundField HeaderText="Name" DataField="ContractName" />--%>
            <asp:BoundField HeaderText="Contract Number" DataField="ContractNumber"/>
            <asp:BoundField HeaderText="Site Address" DataField="SponsorAddress" /> 
              
        </Columns>
    </asp:GridView> 
</asp:Panel>