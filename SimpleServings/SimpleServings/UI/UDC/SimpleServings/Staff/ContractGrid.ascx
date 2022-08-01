<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.ContractGrid" %>

 <asp:Label CssClass="amountFound" ID="lblMsg" runat="server" />

<div class="dataRow" >
<div class="dataInput" >
    <asp:GridView ID="gvContract" runat="server" AutoGenerateColumns="False" 
    
    DataKeyNames="ContractID">
        
     
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cbCheck" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ContractID" Visible="false" />
            <asp:BoundField ControlStyle-CssClass="dataLabel" DataField="ContractName" HeaderText="Contract Name" />
            <asp:BoundField ControlStyle-CssClass="dataLabel" DataField="ContractNumber" HeaderText="Contract Number" />
        </Columns>
    </asp:GridView>
</div>
</div>