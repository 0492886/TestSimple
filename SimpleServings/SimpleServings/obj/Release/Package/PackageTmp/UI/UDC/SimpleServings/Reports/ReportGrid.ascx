<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Reports.ReportGrid" %>

<span class="hidden_msg"><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel CssClass="" ID="pnPage" runat="server">
<div class="dataList">
<asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
<div class="dgContainer">
<asp:GridView  CssClass="DatagridStyle table table-hover"  ID="gvReport" runat="server" 
    AutoGenerateColumns="false">
<Columns>
        <asp:TemplateField HeaderText="Report ID" Visible="false">
            <ItemTemplate>
                <asp:Label ID="lblReportID" runat="server" text='<%#Eval("ReportID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="Report Name">
            <ItemTemplate>
                <asp:Label ID="lblReportName" runat="server" text='<%#Eval("ReportName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Report Description">
             <ItemTemplate>
                <asp:Label ID="lblReportDescription" runat="server" text='<%#Eval("ReportDescription") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
       <asp:TemplateField HeaderText="Report Link" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblReportLink" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportLink") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Report Category" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblcategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportCategory") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="hlDetails" runat="server" CssClass="btn_floatR" Target="_blank" Text="Open" 
                NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "ReportLink") %>' >
                </asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>             
</Columns>
</asp:GridView>
</div>
</div>

</asp:Panel>